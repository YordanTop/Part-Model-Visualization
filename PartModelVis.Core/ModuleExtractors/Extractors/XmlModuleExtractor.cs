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

        private string _moduleVariantPath; 

        public XmlModuleExtractor(FileStream fileInfo)
        {
            _moduleInfoDocument.Load(fileInfo);
           //_moduleVariantPath = ModuleConfigurationManager.ContentScanPath;
        }
        /// <summary>
        /// Извличане на най-съществаната информация за варианта на модула от XML файл.
        /// </summary>
        /// <param name="moduleVariant">Варианта на модела</param>
        /// <returns>Връща инфорамация за модула/returns>
        public Module ExtractPrimaryModuleData(string moduleVariant)
        {
            Module module = new Module();

            XmlNode? columnInfo = XmlTracker(string.Format(_moduleVariantPath,moduleVariant));

            if (columnInfo != null)
            {
                // Добавяне на module стойностите
                module.Variant = moduleVariant;

                module.CarLine = columnInfo.SelectSingleNode("//Column[@name = \"proj_carLine\"]").InnerText;

                module.SRC = columnInfo.SelectSingleNode("//Column[@name = \"proj_src\"]").InnerText;

                module.PCB = columnInfo.SelectSingleNode("//Column[@name = \"proj_pcb\"]").InnerText;

                module.RightLever = columnInfo.SelectSingleNode("//Column[@name = \"proj_rightLever\"]").InnerText;

                module.LeftLever = columnInfo.SelectSingleNode("//Column[@name = \"proj_leftLever\"]").InnerText;

                module.SRCSwitch= columnInfo.SelectSingleNode("//Column[@name = \"proj_srcSwitch\"]").InnerText;
            }
            return module;
        
        }

        /// <summary>
        /// Извличане на цялата информация за варианта на модула от XML файл.
        /// </summary>
        /// <param name="moduleVariant">Варианта на модула.</param>
        /// <returns>Връща инфорамация за модула.</returns>
        public List<ModuleAlternativeProperty> ExtractAllModuleProperties(string moduleVariant)
        {

            List<ModuleAlternativeProperty> productVariantPropertiesList = new List<ModuleAlternativeProperty>();

            
            XmlNode? columnInfo = XmlTracker(_moduleVariantPath.Replace("{variant-number}", moduleVariant));


            if (columnInfo != null)
            {

                foreach (XmlNode column in columnInfo.ChildNodes)
                {
                    productVariantPropertiesList.Add(new ModuleAlternativeProperty()
                    {
                        Name = column.Attributes["name"].Value,
                        Description = column.InnerText
                    });
                }
            }

            return productVariantPropertiesList;
            
        }

        /// <summary>
        /// Извличане на колони под формата на XmlNode от зададения XML път.  
        /// </summary>
        /// <param name="pathToColumn">Пътя за следене</param>
        /// <returns>Връщане на данни под форма на XmlNode.</returns>
        private XmlNode? XmlTracker(string pathToColumn)
        {
            return _moduleInfoDocument.SelectSingleNode(pathToColumn);
        }

        List<ModuleAlternativeProperty> IExtractorType.ExtractAllModuleProperties(string moduleVariant)
        {
            throw new NotImplementedException();
        }
    }
}
