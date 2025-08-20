using PartModelVis.Core.Models;
using PartModelVisualisation.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.ModuleExporters.Interfaces
{
    public interface IExporterType:IDisposable
    {
        /// <summary>
        /// <see cref="SerializeChanges"/> is saving and exporting the module based of the given file format.
        /// </summary>
        
        public void SerializeChanges(Module module);

    }
}
