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
        public int Width { get; set; } = 200; //default value for the width
        public int Height { get; set; } = 200; //default value for the height

        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public double Rotation { get; set; }
    }
}
