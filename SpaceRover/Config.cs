using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRover
{
    internal static class Config
    {
        public static string ApplicationPath = System.IO.Directory.GetCurrentDirectory();


        public static string TempPath = System.IO.Path.GetTempPath();

        public static string TempProjectPath = Path.Combine(System.IO.Path.GetTempPath(), "SpaceRover");
    }
}
