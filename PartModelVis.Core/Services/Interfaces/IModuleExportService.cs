using PartModelVisualisation.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Services.Interfaces
{
    public interface IModuleExportService
    {

        /// <summary>
        /// Save and export the current properties of the model
        /// </summary>
        /// <param name="moduleProperty"></param>
        public void SaveChanges(ModuleAlternativeProperty moduleProperty);
        

    }
}
