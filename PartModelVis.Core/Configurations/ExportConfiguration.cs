using PartModelVis.Core.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Configurations
{
    public static class ExportConfiguration
    {

        public static void ExportChanges(string filePath)
        {
            var fileStream = FileHelper.FetchFile(filePath);

            string extansion = FileHelper.GetExtansion(fileStream);
        }

    }
}
