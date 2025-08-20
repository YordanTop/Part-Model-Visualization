using PartModelVis.Core.Configurations;
using PartModelVis.Core.Models;
using PartModelVis.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Services
{
    public class ModuleExtractService : IModuleExtractService
    {
        public required string FileName { get; set; }


        public Module ExtractModule(string moduleVariant, string moduleCarLine)
        {

            using (ExtractorConfiguration extractorConfiguration = new ExtractorConfiguration())
            {
                var extractor = extractorConfiguration.InitializeExtractor(FileName);
                return extractor.ExtractModule(moduleVariant,moduleCarLine);
            }
        }
    }
}
