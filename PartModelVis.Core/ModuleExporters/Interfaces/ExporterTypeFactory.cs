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
        /// Създаване на инстанция от дадения тип.
        /// </summary>
        /// <param name="file">файла</param>
        /// <returns></returns>
        public abstract IExporterType CreateExporter(FileStream file);
    }
}
