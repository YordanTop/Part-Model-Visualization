using PartModelVis.Core.Helper;
using PartModelVis.Core.ModuleExporters.Exproters;
using PartModelVis.Core.ModuleExporters.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.ModuleExporters.Providers
{
    public class JsonModelExporterProvider : ExporterTypeFactory
    {

        public JsonModelExporterProvider()
        {
            this._extansionFile = FileExtantion.JSON.GetExtention();
        }

        public override IExporterType CreateExporter(FileStream file)
        {
            return new JsonModuleExporter(file);
        }
    }
}
