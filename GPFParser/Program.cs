using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GPFParser
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var file =  File.OpenRead(@"C:\Users\slowt_000\Desktop\garmin profiles\Cycling.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(Profile));
            var profile = serializer.Deserialize(file);
        }
    }
}
