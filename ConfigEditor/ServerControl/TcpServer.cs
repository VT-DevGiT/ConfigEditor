using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Buffers;
using DevExpress.Xpo.Logger;
using System.Drawing;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.XtraPrinting;

namespace ConfigEditor.ServerControl
{
    public class TcpServer
    {
        private readonly Logger _logger;
        private readonly int _port;
        private readonly TcpListener _listener;
        private readonly Thread _receiveThread;
        private readonly Thread _sendThread;
        private readonly UTF8Encoding _utf8;
        private NetworkStream _stream;

        private TcpClient _client;

        private bool _disposing;

        public TcpServer(int port, Logger logger)
        {
            _port = port;
            _utf8 = new UTF8Encoding();

            _receiveThread = new Thread(new ThreadStart(Receive))
            {
                Priority = System.Threading.ThreadPriority.Lowest,
                IsBackground = true,
                Name = "Config Editor TCP input"
            };

            _logger = logger;
            _listener = new TcpListener(new IPEndPoint(IPAddress.Loopback, _port));
            _listener.Start();
            _listener.BeginAcceptTcpClient(callBack =>
            {
                _client = _listener.EndAcceptTcpClient(callBack);
                _stream = _client.GetStream();
                _receiveThread.Start();
            }, _listener);
        }

        public void Dispose()
        {
            _disposing = true;
            try
            {
                if (_receiveThread.IsAlive)
                    _receiveThread.Abort();
            }
            catch { }
            _stream?.Dispose();
            _client?.Dispose();
        }

        private void Receive()
        {
            byte[] buffer = new byte[4];
            while (!_disposing)
            {
                try
                {
                    _stream.Read(buffer, 0, 4);
                    int num = MemoryMarshal.Cast<byte, int>((Span<byte>) buffer)[0];
                    byte[] numArray = ArrayPool<byte>.Shared.Rent(num);
                    _stream.Read(numArray, 0, num);
                    string str = _utf8.GetString(numArray, 0, num);
                    ArrayPool<byte>.Shared.Return(numArray);
                    AddLog(str);
                }
                catch (Exception ex)
                {
                    AddLog("[TcpClient] Receive exception: " + ex.Message);
                    AddLog("[TcpClient] " + ex.StackTrace);
                }
            }
        }

        public void AddLog(string text, ConsoleColor color)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;
            _logger.Invoke(text, Color.FromName(color.ToString()), false);
        }

        public void AddLog(string text) => AddLog(text, ConsoleColor.Gray);

        public void Send(string message)
        {
            try
            {
                var textEntry = new TextOutputEntry(message, ConsoleColor.DarkYellow, _utf8);
                var buffer = ArrayPool<byte>.Shared.Rent(textEntry.GetBytesLength());
                textEntry.GetBytes(ref buffer, out var length);
                this._stream.Write(buffer, 0, length);
                ArrayPool<byte>.Shared.Return(buffer);
                _stream.Write(buffer, 0, length);
            }
            catch (Exception ex)
            {
                AddLog("[TcpClient] Send exception: " + ex.Message);
                AddLog("[TcpClient] " + ex.StackTrace);
            }
        }
    }

    public struct TextOutputEntry : IOutputEntry
    {
        public readonly string Text;
        public readonly byte Color;
        public readonly UTF8Encoding Encoding;
        private const int offset = 5;

        public TextOutputEntry(string text, ConsoleColor color, UTF8Encoding encoding)
        {
            Text = text;
            Color = (byte)color;
            Encoding = encoding;
        }

        private string HexColor => Color.ToString("X");

        public string GetString() => HexColor + Text;

        public int GetBytesLength() => Encoding.GetMaxByteCount(Text.Length) + 5;

        public void GetBytes(ref byte[] buffer, out int length)
        {
            length = Encoding.GetBytes(Text, 0, Text.Length, buffer, 5);
            buffer[0] = this.Color;
            buffer[1] = (byte)((length & 4278190080L)   >> 24);
            buffer[2] = (byte)((length & 16711680)      >> 16);
            buffer[3] = (byte)((length & 65280)         >> 8);
            buffer[4] = (byte)( length & byte.MaxValue);
            length += 5;
        }
    }


    public interface IOutputEntry
    {
        string GetString();

        int GetBytesLength();

        void GetBytes(ref byte[] buffer, out int length);
    }

    public enum OutputCodes : byte
    {
        RoundRestart = 16,              // 0x10
        IdleEnter = 17,                 // 0x11
        IdleExit = 18,                  // 0x12
        ExitActionReset = 19,           // 0x13
        ExitActionShutdown = 20,        // 0x14
        ExitActionSilentShutdown = 21,  // 0x15
        ExitActionRestart = 22,         // 0x16
    }
}
