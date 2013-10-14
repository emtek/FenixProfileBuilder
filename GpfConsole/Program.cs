using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpfConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GpfTools.GpfUtil.FindGarminDeviceDirectory());
            var list = GpfTools.GpfUtil.ProfilesList();
            Console.ReadLine();
        }
    }
}
