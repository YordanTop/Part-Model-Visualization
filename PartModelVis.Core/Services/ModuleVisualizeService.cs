using PartModelVis.Core.Models;
using PartModelVis.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PartModelVis.Core.Services
{
    public class ModuleVisualizeService : IModuleVisualizeService
    {
        public void DragImage(ModulePartImage partImage)
        {
            throw new NotImplementedException();
        }

        public void DropImage(ModulePartImage partImage)
        {
            throw new NotImplementedException();
        }

        public List<ModulePartImage> ImageCollectionInstance(Module module)
        {
            if (module == null)
                return new List<ModulePartImage>();

            var newCollection = new List<ModulePartImage>();

            foreach (var moduleRow in module.ModuleProperties)
            {
                if (string.IsNullOrEmpty(moduleRow.PicturePath))
                    continue;

                newCollection.Add(new ModulePartImage
                {
                    Description = moduleRow.Description,
                    Image = new BitmapImage(new Uri(moduleRow.PicturePath, UriKind.RelativeOrAbsolute))
                });
            }

            return newCollection;
        }

        public void RotateImage(ModulePartImage partImage)
        {
            throw new NotImplementedException();
        }

        public void ScaleImage(ModulePartImage partImage)
        {
            throw new NotImplementedException();
        }
    }
}
