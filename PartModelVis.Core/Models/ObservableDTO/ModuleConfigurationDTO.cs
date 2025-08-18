using CommunityToolkit.Mvvm.ComponentModel;
using PartModelVis.Core.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Models.ObservableDTO
{
    public partial class ModuleConfigurationDTO:ObservableObject
    {
        [ObservableProperty]
        private string _variant;

        [ObservableProperty]
        private string _carLine;

        [ObservableProperty]
        private string _visualFile;

        [ObservableProperty]
        private string _informationFile;



        public ModuleConfiguration ToModel => new()
        {
            Variant = _variant,
            CarLine = _carLine,
            VisualFile = _visualFile,
            InformationFile = _informationFile 
        };

    }
}
