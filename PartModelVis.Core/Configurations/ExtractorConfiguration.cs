using PartModelVis.Core.Helper;
using PartModelVis.Core.ModuleExtractors.Factory;
using PartModelVis.Core.ModuleExtractors.Interfaces;
using PartModelVis.Core.ModuleExtractors.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Configurations
{
    public static class ExtractorConfiguration
    {
        /// <summary>
        /// Makes instance of a module extractor.
        /// </summary>
        /// <param name="filePath">Absoulute file path for the module info.</param>
        /// <returns></returns>
        public static IExtractorType InitializeExtractor(string filePath)
        {
            //Available extansions.
            List<ExtractorTypeFactory> extractorTypeFactories = new List<ExtractorTypeFactory>()
            {
                new XmlModuleExtractorProvider()
            };


            var fileStream = FileHelper.FetchFile(filePath);

            string extansion = FileHelper.GetExtansion(fileStream);

            FactoryExtractors factory = new FactoryExtractors(extractorTypeFactories);

            return factory.CreateExtractor(fileStream, extansion);
        }
    }
}
