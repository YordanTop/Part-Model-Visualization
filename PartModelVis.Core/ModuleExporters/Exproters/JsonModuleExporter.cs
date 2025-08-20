using PartModelVis.Core.Models;
using PartModelVis.Core.ModuleExporters.Interfaces;
using PartModelVisualisation.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PartModelVis.Core.ModuleExporters.Exproters
{
    public class JsonModuleExporter:IExporterType
    {
        private FileStream _file;

        public JsonModuleExporter(FileStream file)
        {
            _file = file;
        }

        public void SerializeChanges(Module module)
        {
            JsonSerializer.Serialize(_file,module);
        }

        public void Dispose()
        {
            _file.Dispose();
        }
    }
}
