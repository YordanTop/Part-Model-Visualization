using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PartModelVis.Core.Models
{
    public class ModulePartImage
    {
        public BitmapImage Image { get; set; }

        public string Description { get; set; }
        public int Width {  get; set; }
        public int Height { get; set; }

        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public double Rotation { get; set; }
    }
}
