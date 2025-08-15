using PartModelVis.Core.Models;
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
        public string FileName { get; set; }
        /// <summary>
        /// Save and export the current properties of the model
        /// </summary>
        /// <param name="moduleProperty"></param>
        public void SaveChanges(Module moduleProperty);
        

    }
}
