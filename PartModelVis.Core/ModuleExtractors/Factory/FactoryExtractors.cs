using PartModelVis.Core.Helper;
using PartModelVis.Core.ModuleExtractors.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.ModuleExtractors.Factory
{
    /// <summary>
    /// FactoryExtractors makes extractors based of the file format. 
    /// </summary>
    public class FactoryExtractors : FactoryHelper<ExtractorTypeFactory, IExtractorType>
    {
        public FactoryExtractors(IList<ExtractorTypeFactory> extractorList)
        {
            ElementTypeList = extractorList;
        }

        public override IExtractorType CreateType(FileStream file, string extansion)
        {
            var extractor = ElementTypeList.FirstOrDefault(extractor => extractor.CheckType(extansion));


            if (extractor == null)
            {
                throw new NotSupportedException($"This extansion '{extansion}' has no extracting support!");
            }

            return extractor.CreateExtractor(file);
        }
    }
}
