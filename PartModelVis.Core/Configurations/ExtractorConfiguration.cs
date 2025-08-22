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
        /// <param name="file">Absoulute file path for the module info.</param>
        /// <returns></returns>
        public static IExtractorType InitializeExtractor(FileStream file)
        {
            List<ExtractorTypeFactory> extractorTypeFactories = new List<ExtractorTypeFactory>()
            {
                new XmlModuleExtractorProvider()
            };

             string extension = GetFileExtension(file);
             FactoryExtractors factory = new FactoryExtractors(extractorTypeFactories);
             return factory.CreateType(file, extension);
            
        }
        private static string GetFileExtension(FileStream fileStream)
        {
            return FileHelper.GetExtansion(fileStream.Name);
        }
    }
}
