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
            IEnumerable<SymlContentItem> lstStructure = list[idxRacine].StructureList().Select(p => p.Copy());
            while (!list[idxInsertAfter].IsLastListItem && !list[idxInsertAfter].IsList && list[idxInsertAfter].IsListItem)
            {
                idxInsertAfter++;
            }

            list.InsertRange(idxInsertAfter + 1, lstStructure);
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
