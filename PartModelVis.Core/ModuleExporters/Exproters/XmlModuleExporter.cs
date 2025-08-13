using PartModelVis.Core.ModuleExporters.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.ModuleExporters.Exproters
{
    public class XmlModuleExporter:IExporterType
    {
        private FileStream _file;

        public XmlModuleExporter(FileStream file)
        {
            _file = file;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
