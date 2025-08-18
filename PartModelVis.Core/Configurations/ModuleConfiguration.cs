using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Configurations
{
    public class ModuleConfiguration
    {
        public string Variant { get; set; }

        public string CarLine { get; set; }

        public string VisualFile { get; set; }  
        public string InformationFile { get; set; } 

        public bool IsModuleLoaded
        {
            get
            {
                var properties = new[] { Variant, CarLine, VisualFile, InformationFile };
                return properties.All(p => !string.IsNullOrEmpty(p));
            }
        }
    }
}
