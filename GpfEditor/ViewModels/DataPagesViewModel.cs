using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using FirstFloor.ModernUI.Presentation;
using GpfTools.GpfFile;

namespace GpfEditor.ViewModels
{
    public class DataPagesViewModel : NotifyPropertyChanged
    {
        private string _fileName;
        private ObservableCollection<ProfileSettingsNavDataPage> _selectedDataPagesItems;
        private ProfileSettings _profileSettings;
        private ProfileSettingsNavDataPage _selectedDataPage;
        private string _selectedPageType;
        private string _selectedPageField1;
        private string _selectedPageField2;
        private string _selectedPageField3;
        public Visibility _field1Vis = Visibility.Visible;
        public Visibility _field2Vis = Visibility.Collapsed;
        public Visibility _field3Vis = Visibility.Collapsed;
        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }

        public DataPagesViewModel(string fileName)
        {
            _fileName = fileName;
             _profileSettings = GpfTools.GpfUtil.ProfilesList().First(p => p.Item1.Contains(_fileName)).Item2.Items[0] as ProfileSettings;
            _selectedDataPagesItems = new ObservableCollection<ProfileSettingsNavDataPage>();
            foreach (var item in _profileSettings.NavDataPage)
            {
                _selectedDataPagesItems.Add(item);
            }
            _selectedDataPagesItems.CollectionChanged += SelectedDataPagesItemsCollectionChanged;
            AddCommand = new RelayCommand(g => _selectedDataPagesItems.Add(new ProfileSettingsNavDataPage()
                                                                               {
                                                                                   DataPageCustomIdx = "0",
                                                                                   DataPageField1 =
                                                                                       new DataPageField1[]
                                                                                           {
                                                                                               new DataPageField1()
                                                                                                   {
                                                                                                       DataPageField
                                                                                                           = "83",
                                                                                                       DataPageFieldLabel
                                                                                                           = "0"
                                                                                                   }
                                                                                           },
                                                                                   DataPageField2 =
                                                                                       new DataPageField2[]
                                                                                           {
                                                                                               new DataPageField2()
                                                                                                   {
                                                                                                       DataPageField
                                                                                                           = "83",
                                                                                                       DataPageFieldLabel
                                                                                                           = "0"
                                                                                                   }
                                                                                           },
                                                                                   DataPageField3 =
                                                                                       new DataPageField3[]
                                                                                           {
                                                                                               new DataPageField3()
                                                                                                   {
                                                                                                       DataPageField
                                                                                                           = "83",
                                                                                                       DataPageFieldLabel
                                                                                                           = "0"
                                                                                                   }
                                                                                           },
                                                                                   DataPageIdx = "0",
                                                                                   DataPageName =
                                                                                       "5",
                                                                                   DataPageType =
                                                                                       "3"
                                                                               }));
            DeleteCommand = new RelayCommand(g => _selectedDataPagesItems.Remove(SelectedDataPage));
        }

        private void SelectedDataPagesItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            _profileSettings.NavDataPage = _selectedDataPagesItems.ToArray();
        }

        public ObservableCollection<ProfileSettingsNavDataPage> SelectedDataPagesItems
        {
            get { return _selectedDataPagesItems; }
            set
            {
                if (_selectedDataPagesItems != value)
                {
                    _selectedDataPagesItems = value;
                    OnPropertyChanged("SelectedDataPagesItems");
                }
            }
        }

        public ProfileSettingsNavDataPage SelectedDataPage
        {
            get { return _selectedDataPage; }
            set {
                if (_selectedDataPage != value && value != null)
                {
                    _selectedDataPage = value;
                    SelectedPageType = value.ToString();
                    SelectedPageField1 = Enums.DataPageFields[int.Parse(value.DataPageField1[0].DataPageField)];
                    SelectedPageField2 = Enums.DataPageFields[int.Parse(value.DataPageField2[0].DataPageField)];
                    SelectedPageField3 = Enums.DataPageFields[int.Parse(value.DataPageField3[0].DataPageField)];
                    
                    OnPropertyChanged("SelectedDataPage");
                } 
            }
        }

        public String SelectedPageField1
        {
            get { return _selectedPageField1; }
            set
            {
                if (_selectedPageField1 != value && value != null)
                {
                    _selectedPageField1 = value;
                    SelectedDataPage.DataPageField1[0].DataPageField =
                        Enums.DataPageFields.FirstOrDefault(s => s.Value == _selectedPageField1).Key.ToString();
                    OnPropertyChanged("SelectedPageField1");
                }
            }
        }

        public String SelectedPageField2
        {
            get { return _selectedPageField2; }
            set
            {
                if (_selectedPageField2 != value && value != null)
                {
                    _selectedPageField2 = value;
                    SelectedDataPage.DataPageField2[0].DataPageField =
                        Enums.DataPageFields.FirstOrDefault(s => s.Value == _selectedPageField2).Key.ToString();
                    OnPropertyChanged("SelectedPageField2");
                }
            }
        }
        public String SelectedPageField3
        {
            get { return _selectedPageField3; }
            set
            {
                if (_selectedPageField3 != value && value != null)
                {
                    _selectedPageField3 = value;
                    SelectedDataPage.DataPageField3[0].DataPageField =
                        Enums.DataPageFields.FirstOrDefault(s => s.Value == _selectedPageField3).Key.ToString();
                    OnPropertyChanged("SelectedPageField3");
                }
            }
        }

        public String SelectedPageType
        {
            get { return _selectedPageType; }
            set
            {
                if (_selectedPageType != value && value != null)
                {
                    if(value == "1 Field")
                    {
                        Field1Vis = Visibility.Visible;
                        Field2Vis = Visibility.Collapsed;
                        Field3Vis = Visibility.Collapsed;
                        SelectedDataPage.DataPageType = "0";
                        SelectedDataPage.DataPageIdx = "8";
                        SelectedDataPage.DataPageField1[0].DataPageFieldLabel = "1";
                    }
                    else if(value == "2 Fields")
                    {
                        Field1Vis = Visibility.Visible;
                        Field2Vis = Visibility.Visible;
                        Field3Vis = Visibility.Collapsed;
                        SelectedDataPage.DataPageType = "1";
                        SelectedDataPage.DataPageIdx = "8";
                        SelectedDataPage.DataPageField1[0].DataPageFieldLabel = "1";
                        SelectedDataPage.DataPageField2[0].DataPageFieldLabel = "1";
                    }else if(value == "3 Fields")
                    {
                        Field1Vis = Visibility.Visible;
                        Field2Vis = Visibility.Visible;
                        Field3Vis = Visibility.Visible;
                        SelectedDataPage.DataPageType = "2";
                        SelectedDataPage.DataPageIdx = "8";
                        SelectedDataPage.DataPageField1[0].DataPageFieldLabel = "1";
                        SelectedDataPage.DataPageField2[0].DataPageFieldLabel = "1";
                        SelectedDataPage.DataPageField3[0].DataPageFieldLabel = "1";
                    }
                    else if (value == "Dual Grid")
                    {
                        Field1Vis = Visibility.Visible;
                        Field2Vis = Visibility.Visible;
                        Field3Vis = Visibility.Collapsed;
                        SelectedDataPage.DataPageIdx = "8";
                        SelectedDataPage.DataPageField1[0].DataPageFieldLabel = "1";
                        SelectedDataPage.DataPageField2[0].DataPageFieldLabel = "1";
                        SelectedDataPage.DataPageType = "4";
                    }
                    else
                    {
                        Field1Vis = Visibility.Collapsed;
                        Field2Vis = Visibility.Collapsed;
                        Field3Vis = Visibility.Collapsed;
                        SelectedDataPage.DataPageType = "3";
                        SelectedDataPage.DataPageIdx = "8";
                        SelectedDataPage.DataPageField1[0].DataPageField = "255";
                        SelectedDataPage.DataPageField2[0].DataPageField = "255";
                        SelectedDataPage.DataPageField3[0].DataPageField = "255";
                        SelectedDataPage.DataPageField1[0].DataPageFieldLabel = "0";
                        SelectedDataPage.DataPageField2[0].DataPageFieldLabel = "0";
                        SelectedDataPage.DataPageField3[0].DataPageFieldLabel = "0";
                    }
                    _selectedPageType = value;
                    SelectedDataPage.DataPageName =
                        Enums.DataPageNames.FirstOrDefault(s => s.Value == _selectedPageType).Key.ToString();
                    OnPropertyChanged("SelectedPageType");
                    OnPropertyChanged("SelectedDataPage");
                }
            }
        }

        public ObservableCollection<String> DataPageTypes
        {
            get
            {
                var coll = new ObservableCollection<String>();
                foreach (var name in Enums.DataPageNames.OrderBy(s => s.Value))
                {
                    coll.Add(name.Value);
                }
                return coll;
            }
        }

        public ObservableCollection<String> DataField1Types
        {
            get
            {
                var coll = new ObservableCollection<String>();
                foreach (var name in Enums.DataPageFields.Where(d => d.Key != 255))
                {
                    coll.Add(name.Value);
                }
                return coll;
            }
        }

        public ObservableCollection<String> DataField2Types
        {
            get
            {
                var coll = new ObservableCollection<String>();
                foreach (var name in Enums.DataPageFields.Where(d => d.Key != 83 && d.Key != 255))
                {
                    coll.Add(name.Value);
                }
                return coll;
            }
        }

        public ObservableCollection<String> DataField3Types
        {
            get
            {
                var coll = new ObservableCollection<String>();
                foreach (var name in Enums.DataPageFields.Where(d => d.Key != 83 && d.Key != 255))
                {
                    coll.Add(name.Value);
                }
                return coll;
            }
        }

        public Visibility Field1Vis
        {
            get { return _field1Vis; }
            set
            {
                if (_field1Vis != value && value != null)
                {
                    _field1Vis = value;
                    OnPropertyChanged("Field1Vis");
                }
            }
        }
        public Visibility Field2Vis
        {
            get { return _field2Vis; }
            set
            {
                if (_field2Vis != value && value != null)
                {
                    _field2Vis = value;
                    OnPropertyChanged("Field2Vis");
                }
            }
        }
        public Visibility Field3Vis
        {
            get { return _field3Vis; }
            set
            {
                if (_field3Vis != value && value != null)
                {
                    _field3Vis = value;
                    OnPropertyChanged("Field3Vis");
                }
            }
        }
    }

}
