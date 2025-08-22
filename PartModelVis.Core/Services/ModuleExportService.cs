using PartModelVis.Core.Configurations;
using PartModelVis.Core.Handlers.Exceptions;
using PartModelVis.Core.Helper;
using PartModelVis.Core.Models;
using PartModelVis.Core.Services.Interfaces;
using PartModelVisualisation.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Services
{
    public class ModuleExportService : IModuleExportService
    {
        public required string FileName { get; set; }

        public void SaveChanges(Module module)
        {
            using (FileStream file = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                var exporter = ExporterConfiguration.InitializeExporter(file);
                exporter.SerializeChanges(module);
            }
        }
    }
}
