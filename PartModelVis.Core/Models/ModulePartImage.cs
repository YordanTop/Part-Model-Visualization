using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PartModelVis.Core.Models
{
    public partial class ModulePartImage:ObservableObject
    {
        [ObservableProperty]
        private BitmapImage _image;
        [ObservableProperty]
        private string _description;
        [ObservableProperty]
        private int _width  = 200; //default value for the width
        [ObservableProperty]
        private int _height = 200; //default value for the height

        [ObservableProperty]
        private double _positionX;
        [ObservableProperty]
        private double _positionY;
        [ObservableProperty]
        private int _rotation;
    }
}
