using PartModelVis.Core.Helper;
using PartModelVis.Core.ModuleExporters.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.ModuleExporters.Factory
{
    public class FactoryExporter: FactoryHelper<ExporterTypeFactory, IExporterType>
    {
        public FactoryExporter(IList<ExporterTypeFactory> exporterList)
        {
            ElementTypeList = exporterList;
        }

        public override IExporterType CreateType(FileStream file, string extansion)
        {
            var exporter = ElementTypeList.FirstOrDefault(exporter => exporter.CheckType(extansion));

            if (exporter == null)
            {
                throw new NotSupportedException($"This extansion '{extansion}' has no exporting support!");
            }

            return exporter.CreateExporter(file);
        }

    }
}
