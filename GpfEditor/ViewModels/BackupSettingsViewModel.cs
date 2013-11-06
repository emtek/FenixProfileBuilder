using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;

namespace GpfEditor.ViewModels
{
    public class BackupSettingsViewModel : NotifyPropertyChanged
    {
        private string directory = GpfTools.GpfUtil.GetBackupDirectory();


        public RelayCommand BackupCommand
        {
            get
            {
                return new RelayCommand(g =>
                                            {
                                                if (String.IsNullOrEmpty(GpfTools.GpfUtil.FindGarminDeviceDirectory()))
                                                {
                                                    var v = new ModernDialog()
                                                                {
                                                                    Title = "Connect Device",
                                                                    Content =
                                                                        "Please connect your device and try again."
                                                                };
                                                    v.ShowDialog();
                                                }
                                                else
                                                {
                                                    GpfTools.GpfUtil.BackupDeviceToRepository();
                                                }
                                            });
            }
        }

        public RelayCommand RevertCommand
        {
            get
            {
                return
                    new RelayCommand(
                        g =>
                            {
                                var firstOrDefault = GitHelpers.GitBackup.GetChangeSets(directory).FirstOrDefault(s => s.Item2 == SelectedBackup);
                                if (firstOrDefault != null)
                                    GitHelpers.GitBackup.RevertToChangeset(GpfTools.GpfUtil.GetBackupDirectory(),
                                                                           firstOrDefault
                                                                               .Item1);
                            });
                                        
            }
        }

        public String SelectedBackup { get; set; }


        public List<string> Backups
        {
            get { return GitHelpers.GitBackup.GetChangeSets(directory).Select(s => s.Item2).ToList(); }
            
        }

        public string BackupDirectory
        {
            get { return this.directory; }
            set
            {
                if (this.directory != value)
                {
                    this.directory = value;
                    OnPropertyChanged("BackupDirectory");
                }
            }
        }
    }
}
