using PartModelVis.Core.Models;
using PartModelVisualisation.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.ModuleExporters.Interfaces
{
    public interface IExporterType
    {
        public void SerializeChanges(Module module);

    }
}
