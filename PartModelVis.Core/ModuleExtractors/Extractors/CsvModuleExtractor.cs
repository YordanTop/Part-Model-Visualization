using PartModelVis.Core.Models;
using PartModelVis.Core.ModuleExtractors.Interfaces;
using PartModelVisualisation.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.ModuleExtractors.Extractors
{
    public class CsvModuleExtractor : IExtractorType
    {
        public Module ExtractPrimaryModuleData(string moduleVariant)
        {
            throw new NotImplementedException();
        }

        public List<ModuleAlternativeProperty> ExtractAllModuleProperties(string moduleVariant)
        {
            throw new NotImplementedException();
        }
    }
}
