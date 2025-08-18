using PartModelVis.Core.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.ModuleExporters.Interfaces
{
    public abstract class ExporterTypeFactory: FactoryTypeHelper
    {
        /// <summary>
        /// <see cref="CreateExporter"/> creates an exproter instance based of the exporter type.
        /// </summary>
        /// <returns>returns <see cref="IExporterType"/> instance</returns>
        public abstract IExporterType CreateExporter(FileStream file);
    }
}
