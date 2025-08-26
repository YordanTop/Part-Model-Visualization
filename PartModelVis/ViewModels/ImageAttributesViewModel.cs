using CommunityToolkit.Mvvm.ComponentModel;
using PartModelVis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartModelVis.ViewModels
{
    public partial class ImageAttributesViewModel:ObservableObject
    {
        [ObservableProperty]
        private ModulePartImage _partImage;

        public ImageAttributesViewModel(ModulePartImage partImage)
        {
            _partImage = partImage;
        }
    }
}