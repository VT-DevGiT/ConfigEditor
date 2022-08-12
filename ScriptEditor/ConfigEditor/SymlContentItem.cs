using ConfigtEditor.Attributes;
using ConfigtEditor.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigtEditor.ConfigEditor
{
    public class SymlContentItem : BaseUintElement
    {
        private static uint NextId = 0;
        private static uint GetId()
        {
            NextId++;
            return NextId - 1;
        }
        
        private uint howManyIndent(string s)
        {
            string cp = s;
            uint result = 0;
            while (cp.StartsWith("  "))
            {
                result++;
                cp = cp.Substring(2);
            }

            if (cp.StartsWith("- "))
            {
                result++;
                IsListItem = true;
                IsFirstListItem = true;
            }
            return result;
        }


        public SymlContentItem(string name, string value) : this(name)
        {
            BoolValue = (value == "true" || value == "false");
            this.Value = value;
        }
        public SymlContentItem(string name) : this()
        {
            this.Name = name;
            Indent = howManyIndent(name);
        }
        public SymlContentItem()
        {
            this.Id = GetId();
            ParentListName = "";
        }

        private List<SymlContentItem> structureList = new List<SymlContentItem>();

        public List<SymlContentItem> StructureList()
        {
            return structureList;
        }

        [ECSDisplayColumn("Name", 1, 40)]
        public string Name { get; set; }
        [ECSDisplayColumn("Value", 2, 20)]
        public string Value { get; set; }

        // [ECSDisplayColumn("Id", 3, 10)]
        public uint Reference => Id;
        //[ECSDisplayColumn("Parent", 3, 40)]
        public string ParentListName { get; set; }
        // [ECSDisplayColumn("indent", 3, 10)]
        //[ECSDisplayColumn("Indent", 3, 40)]
        public uint Indent { get; set; }
        //[ECSDisplayColumn("List", 3, 10)]
        //[ECSDisplayColumn("List", 3, 40)]
        public bool IsList { get; set; }
        //[ECSDisplayColumn("List Item", 3, 10)]
        //[ECSDisplayColumn("List item", 3, 40)]
        public bool IsListItem { get; set; }
        //[ECSDisplayColumn("First List Item", 3, 10)]
        public bool IsFirstListItem { get; set; }
        //[ECSDisplayColumn("Last List Item", 3, 10)]
        public bool IsLastListItem { get; set; }
        //[ECSDisplayColumn("Bool Value", 3, 10)]
        public bool BoolValue { get; set; }

        //[ECSDisplayColumn("Action", 3, 10)]
        public string Action { get; set; }

        public bool IsRoomEdit
        {
            get
            {
                return Name.Trim().ToLower() == "room:";
                //return ValideRooms.Contains(Value);
            }
        }

        public Completor GetCompletor
        {
            get
            {
                return Config.Singleton.GetCompletor(this);
            }
        }

        [ECSDisplayColumn("Space Error", 3, 8)]
        public bool SpaceError
        {
            get
            {
                return !String.IsNullOrEmpty(Name) && (Name.TakeWhile(c => c == ' ').Count() % 2 != 0);
            }
        }

        public SymlContentItem Copy()
        {
            var elem = new SymlContentItem();
            elem.ParentListName = ParentListName;
            elem.Name = Name;
            elem.Indent = Indent;
            elem.IsListItem = IsListItem;
            elem.IsFirstListItem = IsFirstListItem;
            elem.IsLastListItem = IsLastListItem;
            elem.BoolValue = BoolValue;
            return elem;
        }
    }
}
