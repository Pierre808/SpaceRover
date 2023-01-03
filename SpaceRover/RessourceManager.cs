using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRover
{
    internal class RessourceManager
    {
        public static Uri GetImageRessourceUri(string ressourceName)
        {
            return new Uri("pack://application:,,,/imgs/" + ressourceName);
        }

        //public static string WriteResourceToTempFile(string resourceName)
        //{
        //    using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
        //    {
        //        using (var file = new FileStream(Config.TempProjectPath, FileMode.Create, FileAccess.Write))
        //        {
        //            resource.CopyTo(file);

        //            return Config.TempProjectPath + resourceName;
        //        }
        //    }
        //}

        //public static void WriteResourceToFile(string resourceName, string fileName)
        //{
        //    using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
        //    {
        //        using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write))
        //        {
        //            resource.CopyTo(file);
        //        }
        //    }
        //}
    }
}
