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
        private readonly string _fileName;
        public ModuleExportService(string filePath)
        {
            _fileName = filePath;
        }

        public void SaveChanges(ModuleAlternativeProperty moduleProperty)
        {
            
        }
    }
}
