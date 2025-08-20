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
            List<ExtractorTypeFactory> extractorTypeFactories = new List<ExtractorTypeFactory>()
            {
                new XmlModuleExtractorProvider()
            };

            using (FileStream fileStream = OpenFile(filePath))
            {
                string extension = GetFileExtension(fileStream);
                FactoryExtractors factory = new FactoryExtractors(extractorTypeFactories);
                return factory.CreateType(fileStream, extension);
            }
        }

        private static FileStream OpenFile(string filePath)
        {
            return FileHelper.FetchFile(filePath);
        }

        private static string GetFileExtension(FileStream fileStream)
        {
            return FileHelper.GetExtansion(fileStream.Name);
        }
    }
}
