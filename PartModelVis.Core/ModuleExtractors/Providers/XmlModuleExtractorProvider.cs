
using PartModelVis.Core.Helper;
using PartModelVis.Core.ModuleExtractors.Extractors;
using PartModelVis.Core.ModuleExtractors.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.ModuleExtractors.Providers
{
    public class XmlModuleExtractorProvider : ExtractorTypeFactory
    {
        public XmlModuleExtractorProvider()
        {
            this._extansionFile = FileExtantion.XML.GetExtention();
        }

        public override IExtractorType CreateExtractor(FileStream file)
        {
            return new XmlModuleExtractor(file);
        }

    }
}
