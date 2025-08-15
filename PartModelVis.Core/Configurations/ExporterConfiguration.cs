using PartModelVis.Core.Handlers.Exceptions;
using PartModelVis.Core.Helper;
using PartModelVis.Core.ModuleExporters.Factory;
using PartModelVis.Core.ModuleExporters.Interfaces;
using PartModelVis.Core.ModuleExporters.Providers;
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
            //Available extansions.
            List<ExporterTypeFactory> extractorTypeFactories = new List<ExporterTypeFactory>()
            {
                new XmlModuleExporterProvider(),
                new JsonModelExporterProvider(),
                new CsvModuleExporterProvider()
            };


            FileExistsHandler fileExistsHandler = new FileExistsHandler(filePath);

            // if the file does not exist it create a new file otherwise it fetches the existing one.
            FileStream fileStream = fileExistsHandler.IsConditionValued()?
                                                                            FileHelper.FetchFile(filePath):
                                                                            File.Create(filePath);


            string extansion = FileHelper.GetExtansion(fileStream.Name);

            FactoryExporter factory = new FactoryExporter(extractorTypeFactories);

            return factory.CreateType(fileStream, extansion);
        }

    }
}
