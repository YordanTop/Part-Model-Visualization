using PartModelVis.Core.Models;
using PartModelVis.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;
using Point = System.Windows.Point;

namespace PartModelVis.Core.Services
{
    public class ModuleVisualizeService : IModuleVisualizeService
    {
        public List<ModulePartImage> ImageCollectionInstance(Module module)
        {
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
    }
}
