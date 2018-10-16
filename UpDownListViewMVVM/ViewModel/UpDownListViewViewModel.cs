using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace UpDownListViewMVVM
{
    /// <summary>
    /// View model for UserControl UpDownListView
    /// </summary>
    public class UpDownListViewViewModel : PropertyChangedObject
    {
        private ListedItemCollection m_upDownListModel;

        /// <summary>
        /// Default constructor 
        /// </summary>
        public UpDownListViewViewModel()
        {
            UpButtonClickCommand = new RelayCommand(ExecuteUpButtonClickCommand);
            DownButtonClickCommand = new RelayCommand(ExecuteDownButtonClickCommand);

            UpDownListModel = new ListedItemCollection();
        }

        /// <summary>
        /// Constructor with a list of objects
        /// </summary>
        /// <param name="list">List of objects to be displayed in the list view</param>
        public UpDownListViewViewModel(List<Object> list)
        {
            UpButtonClickCommand = new RelayCommand(ExecuteUpButtonClickCommand);
            DownButtonClickCommand = new RelayCommand(ExecuteDownButtonClickCommand);

            UpDownListModel = new ListedItemCollection(list);
        }

        /// <summary>
        /// Command for clicking the Up button
        /// </summary>
        public ICommand UpButtonClickCommand { get; protected set; }

        /// <summary>
        /// Command for clicking the Down button
        /// </summary>
        public ICommand DownButtonClickCommand { get; protected set; }

        /// <summary>
        /// Set/get UpDownList Model object
        /// </summary>
        public ListedItemCollection UpDownListModel
        {
            get
            {
                return m_upDownListModel;
            }

            set
            {
                m_upDownListModel = value;
                NotifyPropertyChanged("UpDownListModel");
            }
        }

        /// <summary>
        /// Action for the UpButtonClickCommand
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteUpButtonClickCommand(object obj)
        {
            if (m_upDownListModel != null)
                m_upDownListModel.MoveUp();
        }

        /// <summary>
        /// Action for the DownButtonClickCommand
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteDownButtonClickCommand(object obj)
        {
            if (m_upDownListModel != null)
                m_upDownListModel.MoveDown();
        }
    }
}
