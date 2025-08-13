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
    public class CsvModuleExporterProvider:ExporterTypeFactory
    {
        public CsvModuleExporterProvider()
        {
            this._extansionFile = FileExtantion.CSV.GetExtention();
        }

        public override IExporterType CreateExporter(FileStream file)
        {
            return new CsvModuleExporter(file);
        }
    }
}
