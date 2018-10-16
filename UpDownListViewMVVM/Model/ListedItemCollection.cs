using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UpDownListViewMVVM
{
    public class ListedItemCollection : PropertyChangedObject
    {
        private ObservableCollection<Object> m_ListItems;
        private Object m_SelectedListItem;

        /// <summary>
        /// Constructor with a list of objects to be displayed in the list view
        /// </summary>
        /// <param name="list">A list of objects to be displayed in the list view</param>
        public ListedItemCollection(List<Object> list = null)
        {
            Objects = list;
        }

        /// <summary>
        /// Set/get all items associated with the list view
        /// </summary>
        public ObservableCollection<Object> ListItems
        {
            get
            {
                return m_ListItems;
            }

            set
            {
                m_ListItems = value;
                NotifyPropertyChanged("ListItems");
            }
        }

        /// <summary>
        /// Set/get the selected item associated with the list view
        /// </summary>
        public Object SelectedListItem
        {
            get
            {
                return m_SelectedListItem;
            }

            set
            {
                m_SelectedListItem = value;
                NotifyPropertyChanged("SelectedListItem");
            }
        }

        /// <summary>
        /// Set/get all objects in this list
        /// </summary>
        public List<Object> Objects
        {
            get { return new List<Object>(m_ListItems); }

            set
            {
                if (value == null)
                {
                    ListItems = null;
                    return;
                }

                m_ListItems = new ObservableCollection<Object>();

                foreach (var item in value)
                    m_ListItems.Add(item);

                ListItems = m_ListItems;
            }
        }

        /// <summary>
        /// Move the selected item up one index
        /// </summary>
        public void MoveUp()
        {
            if (ListItems == null || ListItems.Count < 2 || SelectedListItem == null)
                return;

            var selectedIndex = ListItems.IndexOf(SelectedListItem);
            if (selectedIndex > 0)
            {
                var itemToMoveUp = ListItems[selectedIndex];
                ListItems.RemoveAt(selectedIndex);
                --selectedIndex;
                ListItems.Insert(selectedIndex, itemToMoveUp);
                SelectedListItem = itemToMoveUp;
            }
        }

        /// <summary>
        /// Move the selected item down one index
        /// </summary>
        public void MoveDown()
        {
            if (ListItems == null || ListItems.Count < 2 || SelectedListItem == null)
                return;

            var selectedIndex = ListItems.IndexOf(SelectedListItem);
            if (selectedIndex < ListItems.Count - 1)
            {
                var itemToMoveUp = ListItems[selectedIndex];
                ListItems.RemoveAt(selectedIndex);
                ++selectedIndex;
                ListItems.Insert(selectedIndex, itemToMoveUp);
                SelectedListItem = itemToMoveUp;
            }
        }
    }
}