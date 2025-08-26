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

        public static IExporterType InitializeExporter(FileStream fileStream)
        {
            List<ExporterTypeFactory> extractorTypeFactories = new List<ExporterTypeFactory>()
            {
                new XmlModuleExporterProvider(),
                new JsonModelExporterProvider(),
                new CsvModuleExporterProvider()
            };

            string extension = Path.GetExtension(fileStream.Name);
            FactoryExporter factory = new FactoryExporter(extractorTypeFactories);
    
            return factory.CreateType(fileStream, extension);
            
        }
    }
}
