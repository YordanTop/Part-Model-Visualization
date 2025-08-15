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
        public string VisualFile { get; set; }  
        public string InformationFile { get; set; } 

        public bool IsModuleLoaded
        {
            get
            {
                if(string.IsNullOrEmpty(Variant)) return false;

                if(string.IsNullOrEmpty(VisualFile)) return false;

                if(string.IsNullOrEmpty(InformationFile)) return false;

                return true;
            }
        }
    }
}
