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

        /// <summary>
        /// <see cref="CreateType"/> creates an exporter type if the extansion is currently supported.
        /// </summary>
        /// <returns>Returns an instance of <see cref="IExporterType"/></returns>
        /// <exception cref="NotSupportedException">Throws error when the provided extansion is not supported</exception>
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
