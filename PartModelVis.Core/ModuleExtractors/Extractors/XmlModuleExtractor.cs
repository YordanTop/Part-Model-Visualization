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
        private readonly string _variantXPath = "/Module[Variant={0}]/Variant";
        private readonly string _carLineXPath = "/Module[Variant={0}]/CarLine";
        private readonly string _modulePropertiesXPath = "/Module[Variant={0}]/ModuleProperties/ModuleAlternativeProperty";


        private readonly XmlDocument _moduleInfoDocument = new XmlDocument();

        public XmlModuleExtractor(FileStream fileInfo)
        {
            _moduleInfoDocument.Load(fileInfo);
        }

        public Module ExtractModule(string moduleVariant)
        {
            Module module = new Module();

            // Variant
            module.Variant = _moduleInfoDocument.SelectSingleNode(string.Format(_variantXPath, moduleVariant)).InnerText;

            // CarLine
            module.CarLine = _moduleInfoDocument.SelectSingleNode(string.Format(_carLineXPath, moduleVariant)).InnerText;


            if (module.Variant == null || module.CarLine == null)
                return null; // no matches


            // ModuleAlternativeProperties
            var propertiesNodes = _moduleInfoDocument.SelectNodes(string.Format(_modulePropertiesXPath, moduleVariant));
            var propertiesList = new List<ModuleAlternativeProperty>();

            if (propertiesNodes != null)
            {
                foreach (XmlNode propertyNode in propertiesNodes)
                {
                    var nameNode = propertyNode.SelectSingleNode("Name");
                    var filePropNode = propertyNode.SelectSingleNode("FilePropertyName");
                    var descriptionNode = propertyNode.SelectSingleNode("Description");
                    var picturePathNode = propertyNode.SelectSingleNode("PicturePath");

                    propertiesList.Add(new ModuleAlternativeProperty
                    {
                        Name = nameNode?.InnerText,
                        FilePropertyName = filePropNode?.InnerText,
                        Description = descriptionNode?.InnerText,
                        PicturePath = picturePathNode?.InnerText
                    });
                }
            }

            module.ModuleProperties = propertiesList;


            return module;
        }
    }
}
