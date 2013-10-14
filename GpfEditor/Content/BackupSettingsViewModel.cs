using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstFloor.ModernUI.Presentation;

namespace GpfEditor.Content
{
    public class BackupSettingsViewModel : NotifyPropertyChanged
    {
        private string directory = GpfTools.GpfUtil.GetBackupDirectory();

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
