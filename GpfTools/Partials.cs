using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpfTools.GpfFile
{
    public partial class ProfileSettingsDataPage
    {
        public override string ToString()
        {
            return Enums.DataPageNames[int.Parse(DataPageName)];
        }
    }

    public partial class ProfileSettingsNavDataPage
    {
        public override string ToString()
        {
            return Enums.DataPageNames[int.Parse(DataPageName)];
        }
    }
}
