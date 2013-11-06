using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Navigation;

namespace GpfEditor.ViewModels
{
    public class HomeViewModel : NotifyPropertyChanged
    {
        private Uri _selectedFile;
        private String _selectedSection = "MainMenu";
        private LinkCollection items = new LinkCollection();
        public RelayCommand NewCommand { get; set; }
        public RelayCommand BackupCommand {get{return new RelayCommand(g => GpfTools.GpfUtil.SaveToRepository());}}
        public RelayCommand SaveCommand {get{return new RelayCommand(g =>
                                                                         {
                                                                             if(String.IsNullOrEmpty(GpfTools.GpfUtil.FindGarminDeviceDirectory()))
                                                                             {
                                                                                 var v = new ModernDialog()
                                                                                             {
                                                                                                 Title = "Error",
                                                                                                 Content =
                                                                                                     "Please connect your device and try again."
                                                                                             };
                                                                                 v.ShowDialog();
                                                                             }
                                                                             else
                                                                             {
                                                                                 GpfTools.GpfUtil.SaveToDevice();
                                                                             }                           
                                                                         });}}
        public RelayCommand DeleteCommand { get; set; }

        public HomeViewModel(string selectedSection)
        {
            _selectedSection = selectedSection;
            if (GpfTools.GpfUtil.ProfilesList().Count < 1)
            {
                if (String.IsNullOrEmpty(GpfTools.GpfUtil.FindGarminDeviceDirectory()))
                {
                    var cancelButton = new Button
                    {
                        Content = "OK",
                        IsDefault = true,
                        IsCancel = true,
                        MinHeight = 21,
                        MinWidth = 65,
                        Margin = new Thickness(4, 0, 0, 0)
                    };
                    var v = new ModernDialog()
                    {
                        Title = "Connect Device",
                        Content =
                            "Please connect your device and try again.",
                        Buttons =
                    new Button[]
                                                                          {
                                                                              cancelButton
                                                                          }
                            
                    };
                    cancelButton.Click += (sender, args) => App.Current.MainWindow.Close();
                    v.ShowDialog();
                }
                else
                {
                    GpfTools.GpfUtil.BackupDeviceToRepository();
                }
            }
            var fileList =
                GpfTools.GpfUtil.ProfilesList().Select(s => Path.GetFileName(s.Item1).Replace(".gpf", string.Empty));
            foreach (var file in fileList)
            {
                items.Add(new Link()
                              {
                                  DisplayName = file,
                                  Source = new Uri("/Content/"+_selectedSection+".xaml?file=" + file, UriKind.Relative)
                              });
            }
            SelectedFile = items.First().Source;
            SetNewCommand();

            DeleteCommand = new RelayCommand(g =>
                                                 {
                                                     GpfTools.GpfUtil.DeleteProfile(
                                                         SelectedFile.ToString().Split('=').Last());
                                                     items.Remove(Files.First(s => s.Source == SelectedFile));
                                                 });
        }

        public LinkCollection Files
        {
            get { return this.items; }
            set
            {
                if (this.items != value)
                {
                    this.items = value;
                    OnPropertyChanged("Files");
                }
            }
        }

        public Uri SelectedFile
        {
            get { return _selectedFile; }
            set
            {
                if (_selectedFile != value)
                {
                    _selectedFile = value;
                    OnPropertyChanged("SelectedFile");
                }
            }
        }

        private void SetNewCommand()
        {
            var filenamebox = new TextBox();
            var addButton = new Button
            {
                Content = "Add",
                IsDefault = true,
                IsCancel = true,
                MinHeight = 21,
                MinWidth = 65,
                Margin = new Thickness(4, 0, 0, 0)
            };
            var v = new ModernDialog
            {
                Title = "New Profile",
                Content = filenamebox,
                Buttons =
                    new Button[]
                                                                          {
                                                                              addButton,
                                                                              new Button()
                                                                                  {IsCancel = true, Content = "Cancel"}
                                                                          }
            };
            addButton.Click += (sender, args) =>
            {
                GpfTools.GpfUtil.AddNewProfile(
                    SelectedFile.ToString().Split('=').Last
                        (), filenamebox.Text);
                items.Add(new Link()
                {
                    DisplayName =
                        filenamebox.Text,
                    Source =
                        new Uri(
                        "/Content/" + _selectedSection + ".xaml?file=" +
                        filenamebox.Text,
                        UriKind.Relative)
                });
                args.Handled = true;
            };
            NewCommand = new RelayCommand(g => v.ShowDialog());
        }
    }
}