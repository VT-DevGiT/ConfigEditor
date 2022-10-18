using ConfigtEditor.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigtEditor.ConfigEditor
{
    public class SymlDetailManager : FixedListManager<SymlContentItem>
    {
        private SymlSection _section;
        public void CreateListEntry(SymlContentItem element)
        {
            var list = _section.Contents();
            int idxRacine = list.IndexOf(element);
            int idxInsertAfter = idxRacine;
            while (!list[idxRacine].IsList)
            {
                idxRacine--;
            }
            List<SymlContentItem> lstStructure = list[idxRacine].StructureList().Select(p => p.Copy()).ToList();
            if (!lstStructure.Any())
            {
                lstStructure = new List<SymlContentItem>();
                var elem = element.Copy();
                elem.Name = "- ";
                lstStructure.Add(elem);
            }
            while (!list[idxInsertAfter].IsLastListItem && !list[idxInsertAfter].IsList && list[idxInsertAfter].IsListItem)
            {
                idxInsertAfter++;
            }
            var toAdd = new List<SymlContentItem>();
            foreach(var item in lstStructure)
            {
                item.Value = "";
                var completor = item.GetCompletor;
                if (completor != null)
                {
                    if (completor.ListValues.Any())
                    {
                        item.Value = completor.ListValues.First().Value;
                    }
                }
                toAdd.Add(item);
            }
            list.InsertRange(idxInsertAfter + 1, toAdd);
            LoadList(list);
        }

        internal void DeleteListEntry(SymlContentItem element)
        {
            var list = _section.Contents();
            var listToDelete = new List<SymlContentItem>();
            int idxRacine = list.IndexOf(element);

            while (!list[idxRacine].IsFirstListItem)
            {
                idxRacine--;
            }
            listToDelete.Add(list[idxRacine]);
            while (!list[idxRacine].IsLastListItem)
            {
                idxRacine++;
                listToDelete.Add(list[idxRacine]);

            }


            list.RemoveAll(p => listToDelete.Contains(p));
            LoadList(list);
        }

        internal void LoadContent(SymlSection item)
        {
            _section = item;
            LoadList(item.Contents());
        }
    }
}
