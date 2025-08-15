using PartModelVis.Core.Models;
using PartModelVis.Core.ModuleExporters.Interfaces;
using PartModelVisualisation.Core.Models;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.ModuleExporters.Exproters
{
    public class CsvModuleExporter : IExporterType
    {
        private FileStream _file;

        public CsvModuleExporter(FileStream file)
        {
            _file = file;
        }

        public void SerializeChanges(Module module)
        {
            string csvString = CsvSerializer.SerializeToCsv(new[] { module });

            byte[] csvStringToByte = Encoding.UTF8.GetBytes(csvString); 

            _file.Write(csvStringToByte, 0, csvStringToByte.Length);    
        }
    }
}
