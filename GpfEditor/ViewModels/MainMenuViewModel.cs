using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FirstFloor.ModernUI.Presentation;
using GongSolutions.Wpf.DragDrop;
using GpfTools.GpfFile;

namespace GpfEditor.ViewModels
{
    public class MainMenuViewModel : NotifyPropertyChanged, IDropTarget
    {
        private string _fileName;
        private ObservableCollection<MenuItem> _selectedMainMenuItems;
        private ObservableCollection<MenuItem> _availableMainMenuItems;
        private ProfileSettings _profileSettings;

        public MainMenuViewModel(string fileName)
        {
            _fileName = fileName;
             _profileSettings = GpfTools.GpfUtil.ProfilesList().First(p => p.Item1.Contains(_fileName)).Item2.Items[0] as ProfileSettings;
            _selectedMainMenuItems = new ObservableCollection<MenuItem>();
            _availableMainMenuItems = new ObservableCollection<MenuItem>();
            foreach (var item in _profileSettings.MainMenu)
            {
                _selectedMainMenuItems.Add(new MenuItem() { Id = int.Parse(item.Value), Value = Enums.MmItems[int.Parse(item.Value)], Selected = true});
            }
            foreach (var available in Enums.MmItems.Where(k => _selectedMainMenuItems.All(g => g.Id != k.Key)))
            {
                _availableMainMenuItems.Add(new MenuItem() { Id = available.Key, Value = available.Value,Selected = false});
            }
            _selectedMainMenuItems.CollectionChanged +=_selectedMainMenuItems_CollectionChanged;
        }

        private void _selectedMainMenuItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            _profileSettings.MainMenu = _selectedMainMenuItems.Select(s => new ProfileSettingsMainMenuMmItem(){ Value = s.Id.ToString()}).ToArray();
        }

        public ObservableCollection<MenuItem> SelectedMainMenuItems
        {
            get { return _selectedMainMenuItems; }
            set
            {
                if (_selectedMainMenuItems != value)
                {
                    _selectedMainMenuItems = value;
                    OnPropertyChanged("SelectedMenuItems");
                }
            }
        }

        public ObservableCollection<MenuItem> AvailableMainMenuItems
        {
            get { return _availableMainMenuItems; }
            set
            {
                if (_availableMainMenuItems != value)
                {
                    _availableMainMenuItems = value;
                    OnPropertyChanged("AvailableMenuItems");
                }
            }
        }

        public class MenuItem
        {
            public int Id;
            public string Value;
            public bool Selected;
            public override string ToString()
            {
                return Value;
            }
        }

        /// <summary>
        /// Updates the current drag state.
        /// </summary>
        /// <param name="dropInfo">Information about the drag.
        ///             </param>
        /// <remarks>
        /// To allow a drop at the current drag position, the <see cref="P:GongSolutions.Wpf.DragDrop.DropInfo.Effects"/> property on 
        ///             <paramref name="dropInfo"/> should be set to a value other than <see cref="F:System.Windows.DragDropEffects.None"/>
        ///             and <see cref="P:GongSolutions.Wpf.DragDrop.DropInfo.Data"/> should be set to a non-null value.
        /// </remarks>
        public void DragOver(IDropInfo dropInfo)
        {
            MenuItem sourceItem = dropInfo.Data as MenuItem;
            MenuItem targetItem = dropInfo.TargetItem as MenuItem;

            if (sourceItem != null)
            {
                dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
                dropInfo.Effects = DragDropEffects.Copy;
            }
        }

        /// <summary>
        /// Performs a drop.
        /// </summary>
        /// <param name="dropInfo">Information about the drop.
        ///             </param>
        public void Drop(IDropInfo dropInfo)
        {
            MenuItem sourceItem = dropInfo.Data as MenuItem;
            MenuItem targetItem = dropInfo.TargetItem as MenuItem;
            if (targetItem == null)
            {
                
                if (sourceItem.Selected)
                {
                    _availableMainMenuItems.Add(sourceItem);
                    _selectedMainMenuItems.Remove(sourceItem);
                }
                else
                {
                    _selectedMainMenuItems.Add(sourceItem);
                    _availableMainMenuItems.Remove(sourceItem);
                }
                sourceItem.Selected = !sourceItem.Selected;
            }
            else
            {
                if (sourceItem.Selected && !targetItem.Selected)
                {
                    sourceItem.Selected = !sourceItem.Selected;
                    _selectedMainMenuItems.Remove(sourceItem);
                    _availableMainMenuItems.Insert(_availableMainMenuItems.IndexOf(targetItem), sourceItem);
                }
                else if (!sourceItem.Selected && targetItem.Selected)
                {
                    sourceItem.Selected = !sourceItem.Selected;
                    _availableMainMenuItems.Remove(sourceItem);
                    _selectedMainMenuItems.Insert(_selectedMainMenuItems.IndexOf(targetItem), sourceItem);
                }
                else if (sourceItem.Selected == targetItem.Selected)
                {
                    if (sourceItem.Selected)
                    {
                        _selectedMainMenuItems.Move(_selectedMainMenuItems.IndexOf(sourceItem),
                                                    _selectedMainMenuItems.IndexOf(targetItem));
                    }
                    else
                    {
                        _availableMainMenuItems.Move(_availableMainMenuItems.IndexOf(sourceItem),
                                                     _availableMainMenuItems.IndexOf(targetItem));
                    }
                }
            }
        }
    }
}
