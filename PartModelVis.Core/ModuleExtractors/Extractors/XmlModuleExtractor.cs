using PartModelVis.Core.Configurations;
using PartModelVis.Core.Models;
using PartModelVis.Core.ModuleExtractors.Interfaces;
using PartModelVis.Core.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using PartModelVisualisation.Core.Models;

namespace PartModelVis.Core.ModuleExtractors.Extractors
{
    public class XmlModuleExtractor: IExtractorType
    {

        private readonly XmlDocument _moduleInfoDocument = new XmlDocument();

        public XmlModuleExtractor(FileStream fileInfo)
        {
            _moduleInfoDocument.Load(fileInfo);
        }

        public Module ExtractModule(string moduleVariant)
        {
            throw new NotImplementedException();
        }
    }
}
