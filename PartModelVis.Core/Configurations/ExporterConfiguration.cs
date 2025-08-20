using PartModelVis.Core.Handlers.Exceptions;
using PartModelVis.Core.Helper;
using PartModelVis.Core.ModuleExporters.Factory;
using PartModelVis.Core.ModuleExporters.Interfaces;
using PartModelVis.Core.ModuleExporters.Providers;
using PartModelVis.Core.ModuleExtractors.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Configurations
{
    public static class ExporterConfiguration
    {

        public static IExporterType InitializeExporter(string filePath)
        {
            List<ExporterTypeFactory> extractorTypeFactories = new List<ExporterTypeFactory>()
            {
                new XmlModuleExporterProvider(),
                new JsonModelExporterProvider(),
                new CsvModuleExporterProvider()
            };

            using (FileStream fileStream = OpenOrCreateFile(filePath))
            {
                string extension = GetFileExtension(fileStream);
                FactoryExporter factory = new FactoryExporter(extractorTypeFactories);
                return factory.CreateType(fileStream, extension);
            }
        }


        private static FileStream OpenOrCreateFile(string filePath)
        {
            FileExistsHandler fileExistsHandler = new FileExistsHandler(filePath);
            return fileExistsHandler.IsConditionValid()
                ? FileHelper.FetchFile(filePath)
                : File.Create(filePath);
        }

        private static string GetFileExtension(FileStream fileStream)
        {
            return FileHelper.GetExtansion(fileStream.Name);
        }

    }
}
