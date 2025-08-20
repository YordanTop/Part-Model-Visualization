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
    public class ExtractorConfiguration:IDisposable
    {

        private FileStream _file;
        /// <summary>
        /// Makes instance of a module extractor.
        /// </summary>
        /// <param name="filePath">Absoulute file path for the module info.</param>
        /// <returns></returns>
        public IExtractorType InitializeExtractor(string filePath)
        {
            List<ExtractorTypeFactory> extractorTypeFactories = new List<ExtractorTypeFactory>()
            {
                new XmlModuleExtractorProvider()
            };

            _file = OpenFile(filePath);

             string extension = GetFileExtension(_file);
             FactoryExtractors factory = new FactoryExtractors(extractorTypeFactories);
             return factory.CreateType(_file, extension);
            
        }

        private FileStream OpenFile(string filePath)
        {
            return FileHelper.FetchFile(filePath);
        }

        private string GetFileExtension(FileStream fileStream)
        {
            return FileHelper.GetExtansion(fileStream.Name);
        }

        public void Dispose()
        {
            _file?.Close();
        }
    }
}
