using PartModelVis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Services.Interfaces
{
    public interface IModuleVisualizeService
    {

        public List<ModulePartImage> ImageCollectionInstance(Module module);

        public void DragImage(ModulePartImage partImage);

        public void DropImage(ModulePartImage partImage);

        public void RotateImage(ModulePartImage partImage);

        public void ScaleImage(ModulePartImage partImage);
    }
}
