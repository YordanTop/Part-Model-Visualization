using PartModelVis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

namespace PartModelVis.Core.Services.Interfaces
{
    public interface IModuleVisualizeService
    {
        public List<ModulePartImage> ImageCollectionInstance(Module module);
    }
}
