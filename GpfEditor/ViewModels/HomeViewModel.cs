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

namespace GpfEditor.ViewModels
{
    public class HomeViewModel : NotifyPropertyChanged
    {
        private Uri _selectedFile;
        private LinkCollection items = new LinkCollection();
        public RelayCommand NewCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }

        public HomeViewModel()
        {
            var fileList =
                GpfTools.GpfUtil.ProfilesList().Select(s => Path.GetFileName(s.Item1).Replace(".gpf", string.Empty));
            foreach (var file in fileList)
            {
                items.Add(new Link()
                              {
                                  DisplayName = file,
                                  Source = new Uri("/Content/MainMenu.xaml?file=" + file, UriKind.Relative)
                              });
            }
            SelectedFile = items.First().Source;
            NewCommand = new RelayCommand(g =>
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
                                                                                                   "/Content/MainMenu.xaml?file=" +
                                                                                                   filenamebox.Text,
                                                                                                   UriKind.Relative)
                                                                                           });
                                                                             args.Handled = true;
                                                                             
                                                                            
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
                                                  v.ShowDialog();
                                              });

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
    }
}