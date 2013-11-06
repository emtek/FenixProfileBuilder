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

        public static Dictionary<int, string> DataPageNames
        {
            get
            {
                return new Dictionary<int, string>()
                       {
                          { 1796, "Alt. Zones"}, 
                          { 5, "Altimeter"}, 
                          { 7, "Barometer"}, 
                          { 12, "Cadence"}, 
                          { 9, "Compass"}, 
                          { 1, "Dual Grid"}, 
                          { 13, "Heart Rate"}, 
                          { 10, "Map"}, 
                          { 8, "Temp."}, 
                          { 11, "Time"},
                          { 1575, "Barometer"},
                          { 1710, "Compass"},
                          { 2, "1 Field"}, 
                          { 3, "2 Fields"}, 
                          { 4, "3 Fields"}
                       };
            }
        }

        public static Dictionary<int, string> DataPageFields
        {
            get
            {
                return new Dictionary<int, string>()
                       {
                          { 255, "Special"}, 
                          { 45, "Dual Grid"}, 
                          { 83, "None"}, 
                          { 47, "Accuracy"}, 
                          { 37, "Amb. Press."}, 
                          { 31, "Ascent"},
                          { 39, "Avg Ascent"},
                          { 60, "Avg Cadence"},
                          { 61, "Avg Descent"},
                          { 32, "Avg HR"},
                          { 94, "Avg HR%"},
                          { 62, "Avg Lap"},
                          { 55, "Avg Pace"},
                          { 21, "Avg Speed"},
                          { 51, "Barometer"},
                          { 38, "Battery"},
                          { 0, "Bearing"},
                          { 63, "Cadence"},
                          { 50, "Calories"},
                          { 64, "Cmp Hdng"},
                          { 1, "Compass"},
                          { 53, "Course"},
                          { 56, "Date"},
                          { 23, "Descent"},
                          { 40, "Distance"},
                          { 97, "Elapsed"},
                          { 8, "Elevation"},
                          { 12, "Final Dest"},
                          { 9, "Final Dist"},
                          { 11, "Final ETA"},
                          { 10, "Final ETE"},
                          { 85, "Final VDST"},
                          { 41, "Final VSPD"},
                          { 43, "Glide Ratio"},
                          { 52, "GPS"},
                          { 58, "GPS Elevation"},
                          { 57, "GPS Heading"},
                          { 42, "GR Dest"},
                          { 16, "Grade"},
                          { 59, "Heading"},
                          { 49, "Heart Rate"},
                          { 65, "HR % Max"},
                          { 93, "HR Zone"},
                          { 67, "Lap Ascent"},
                          { 68, "Lap Cadence"},
                          { 70, "Lap Descent"},
                          { 69, "Lap Dist"},
                          { 95, "Lap Heart Rate"},
                          { 71, "Lap HR %"},
                          { 72, "Lap Pace"},
                          { 86, "Lap Speed"},
                          { 73, "Lap Time"},
                          { 87, "Lap Total"},
                          { 74, "Laps"},
                          { 66, "Last Lap Ascent"},
                          { 76, "Last Lap Cadence"},
                          { 77, "Last Lap Decent"},
                          { 75, "Last Lap Distance"},
                          { 78, "Last Lap HR"},
                          { 80, "Last Lap Pace"},
                          { 79, "Last Lap Speed"},
                          { 88, "Last Lap Time"},
                          { 34, "Max Ascent"},
                          { 33, "Max Descent"},
                          { 35, "Max Elevation"},
                          { 92, "Max Speed"},
                          { 19, "Max Temp"},
                          { 36, "Min Elevation"},
                          { 20, "Min Temp"},
                          { 91, "Moving Avg"},
                          { 24, "Moving Time"},
                          { 5, "Next Destination"},
                          { 4, "Next Dist"},
                          { 6, "Next ETA"},
                          { 89, "Next ETE"},
                          { 7, "Next VDST"},
                          { 2, "Odometer"},
                          { 22, "Off Course"},
                          { 81, "Pace"},
                          { 96, "Speed"},
                          { 13, "Steps"},
                          { 25, "Stop Time"},
                          { 14, "Stopwatch"},
                          { 82, "Sunrise"},
                          { 15, "Sunset"},
                          { 26, "Temp"},
                          { 48, "Time"},
                          { 54, "Timer"},
                          { 28, "To Course"},
                          { 3, "TOD"},
                          { 90, "Track Distance"},
                          { 17, "Turn"},
                          { 44, "Vert Speed"},
                          { 18, "VMG"}
                       };
            }
        }


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
