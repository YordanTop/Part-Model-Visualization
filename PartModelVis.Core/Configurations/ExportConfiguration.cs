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
    public static class ExportConfiguration
    {

        public static IExporterType InitializeExporter(string filePath)
        {
            //Available extansions.
            List<ExporterTypeFactory> extractorTypeFactories = new List<ExporterTypeFactory>()
            {
                new XmlModuleExporterProvider()
            };


            var fileStream = FileHelper.FetchFile(filePath);

            string extansion = FileHelper.GetExtansion(fileStream);

            FactoryExporter factory = new FactoryExporter(extractorTypeFactories);

            return factory.CreateType(fileStream, extansion);
        }

    }
}
