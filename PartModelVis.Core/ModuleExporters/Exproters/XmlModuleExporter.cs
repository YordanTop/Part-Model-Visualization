using PartModelVis.Core.Models;
using PartModelVis.Core.ModuleExporters.Interfaces;
using PartModelVisualisation.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PartModelVis.Core.ModuleExporters.Exproters
{
    public class XmlModuleExporter:IExporterType
    {
        private FileStream _file;
        private XmlSerializer _serializer;

        public XmlModuleExporter(FileStream file)
        {
            _file = file;
            _serializer = new XmlSerializer(typeof(Module));
        }

        public void SerializeChanges(Module module)
        {
      
           _serializer.Serialize(_file, module);
        }

        public void Dispose()
        {
            _file.Dispose();
        }
    }
}
