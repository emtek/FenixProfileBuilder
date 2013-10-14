using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpfTools.GpfFile
{
    public class Enums
    {
        public static Dictionary<int, string> MmItems { get
        {
            return new Dictionary<int, string>()
                       {
                          { 5, "Setup"}, 
                          { 19, "GPS Tools"}, 
                          { 6, "Waypoints"}, 
                          { 14, "Profiles"}, 
                          { 23, "FIT History"}, 
                          { 21, "Clock"}, 
                          { 22, "Alerts"}, 
                          { 9, "Tracks"}, 
                          { 8, "Routes"}, 
                          { 10, "Share Data"}, 
                          { 11, "Active Route"}, 
                          { 15, "Area Calc"}, 
                          { 20, "Coords"}, 
                          { 7, "Geocaches"}, 
                          { 17, "Hunt & Fish"}, 
                          { 2, "MOB"}, 
                          { 1, "POIs"}, 
                          { 18, "Satellite"}, 
                          { 13, "Sight n Go"}, 
                          { 16, "Sun & Moon"}, 
                          { 12, "Wpt avg"},
                          { 27, "Virb Remote"}
                       };
        } }

        public static Dictionary<int, string> MapOrientation
        {
            get
            {
                return new Dictionary<int, string>()
                       {
                          { 1, "Track up"}, 
                          { 0, "North up"}
                       };
            }
        }
        public static Dictionary<int, string> GoToLine
        {
            get
            {
                return new Dictionary<int, string>()
                       {
                          { 0, "Bearing"}, 
                          { 1, "Course"}
                       };
            }
        }
        public static Dictionary<int, string> TimeFormat
        {
            get
            {
                return new Dictionary<int, string>()
                       {
                          { 0, "Standard"}
                       };
            }
        }
       public static Dictionary<int, string> TimeZone
        {
            get
            {
                return new Dictionary<int, string>()
                       {
                          { 28, "NZ"}
                       };
            }
        }
       public static Dictionary<int, string> DistanceUnits
        {
            get
            {
                return new Dictionary<int, string>()
                       {
                          { 9, "Metric"}
                       };
            }
        }
       public static Dictionary<int, string> ElevationUnits
        {
            get
            {
                return new Dictionary<int, string>()
                       {
                          { 35, "Metres"}
                       };
            }
        }
       public static Dictionary<int, string> DepthUnits
       {
           get
           {
               return new Dictionary<int, string>()
                       {
                          { 11, "Metres"}
                       };
           }
       }
       public static Dictionary<int, string> TemperatureUnits
       {
           get
           {
               return new Dictionary<int, string>()
                       {
                          { 37, "C"}
                       };
           }
       }
       public static Dictionary<int, string> PressureUnits
       {
           get
           {
               return new Dictionary<int, string>()
                       {
                          { 27, "Millibar"}
                       };
           }
       }
       public static Dictionary<int, string> SensorMode
       {
           get
           {
               return new Dictionary<int, string>()
                       {
                          { 0, "Auto"},
                          { 1, "Allways On"}
                       };
           }
       }
    }
}
