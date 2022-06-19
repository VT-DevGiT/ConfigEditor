using ScriptEditor.Attributes;
using ScriptEditor.Elements;
using ScriptEditor.Interfaces;
using ScriptEditor.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptEditor.ConfigEditor
{
    public class Room : BaseStringElement
    {
        //  public override string Id { get => Name; set => Name = value; }
        [ECSDisplayColumn("Name", 1, 20)]
        public string Name { get; set; }
        public Room()
        {

        }
        public Room(string name)
        {
            Id = name;
            Name = name;
        }
    }
    public class RoomManager : IListManager<Room>, IWriteManager
    {
        private List<Room> Elements { get; set; }
        public IEnumerable<Room> ElementList => Elements;

        public object CurrentObject { get; set; }

        public Room CurrentRoom => CurrentObject as Room;
        public RoomManager()
        {
            BuildList();
        }

        private void BuildList()
        {
            //Elements = Program.Config.ValideRooms.Select(p => new Room(p)).ToList();
        }

        public event EventHandler ElementListUpdated;

        public DelStatus Delete(Room element)
        {
            Elements.Remove(element);
            //Program.Config.ValideRooms.Remove(element.Name);
            Config.Singleton.Save();
            OnElementListUpdated();
            return DelStatus.Success;
        }

        public void LoadList()
        {
            Elements.Clear();
            //Elements.AddRange(Program.Config.ValideRooms.Select(p => new Room(p)).ToList());
            OnElementListUpdated();
        }

        public void UnloadList()
        {
            Elements.Clear();
            OnElementListUpdated();
        }

        protected void OnElementListUpdated()
        {
            if (ElementListUpdated != null)
            {
                ElementListUpdated(this, EventArgs.Empty);
            }
        }

        public void UpdateElement(object sender)
        {
        }

        public IDictionary<Room, DelStatus> Delete(IEnumerable<Room> element)
        {
            throw new NotImplementedException();
        }

        public void PrepareNew()
        {
            CurrentObject = new Room();
        }

        public bool Save()
        {
            if (Elements.Any(p => p.Id != CurrentRoom.Id && p.Name == CurrentRoom.Name))
            {
                System.Windows.Forms.MessageBox.Show("A room with that name already exist!");
                return true;
            }
            //Program.Config.ValideRooms.Remove(CurrentRoom.Id);
            //Program.Config.ValideRooms.Add(CurrentRoom.Name);
            Elements.Remove(CurrentRoom);
            CurrentRoom.Id = CurrentRoom.Name;
            Elements.Add(CurrentRoom);
            OnElementListUpdated();
            return true;
        }
    }
}
