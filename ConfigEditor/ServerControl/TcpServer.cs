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

namespace ConfigEditor.ServerControl
{
    public class TcpServer
    {
        private bool _disposing;
        private NetworkStream _stream;
        private readonly Logger _logger;
        private readonly int _port;
        private readonly TcpClient _client;
        private readonly Thread _receiveThread;
        private readonly Thread _queueThread;
        private readonly ConcurrentQueue<IOutputEntry> _prompterQueue = new ConcurrentQueue<IOutputEntry>();
        private readonly UTF8Encoding _utf8;

        public TcpServer(int port, Logger logger)
        {
            _logger = logger;
            _client = new TcpClient();
            _receiveThread = new Thread(new ThreadStart(Receive))
            {
                Priority = System.Threading.ThreadPriority.Lowest,
                IsBackground = true,
                Name = "Config Editor input"
            };
            _queueThread = new Thread(new ThreadStart(Send))
            {
                Priority = System.Threading.ThreadPriority.Lowest,
                IsBackground = true,
                Name = "Config Editor output"
            };
            _port = port;
            _utf8 = new UTF8Encoding();
        }

        public void Start()
        {
            _client.Connect(new IPEndPoint(IPAddress.Loopback, (int)_port));
            _stream = _client.GetStream();
            _queueThread.Start();
            _receiveThread.Start();
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
            try
            {
                if (_queueThread.IsAlive)
                    _queueThread.Abort();
            }
            catch { }
            _stream?.Dispose();
            _client.Dispose();
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
            _logger?.Invoke(text, Color.FromName(color.ToString()), false);
        }

        public void AddLog(string text) => AddLog(text, ConsoleColor.Gray);

        public void AddOutput(IOutputEntry entry)
        {
            _prompterQueue.Enqueue(entry);
        }

        private void Send()
        {
            while (!_disposing)
            {
                if (_prompterQueue.Count == 0)
                {
                    Thread.Sleep(25);
                }
                else
                {
                    try
                    {
                        IOutputEntry result;
                        if (_prompterQueue.TryDequeue(out result))
                        {
                            byte[] buffer = ArrayPool<byte>.Shared.Rent(result.GetBytesLength());
                            int length;
                            result.GetBytes(ref buffer, out length);
                            _stream.Write(buffer, 0, length);
                            ArrayPool<byte>.Shared.Return(buffer);
                        }
                    }
                    catch (Exception ex)
                    {
                        AddLog("[TcpClient] Send exception: " + ex.Message);
                        AddLog("[TcpClient] " + ex.StackTrace);
                    }
                }
            }
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
