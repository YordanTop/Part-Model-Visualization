using CommunityToolkit.Mvvm.ComponentModel;
using PartModelVis.Core.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Models.ObservableDTO
{
    public partial class ModuleDTO: ObservableObject
    {
        [ObservableProperty]
        private string _variant;

        [ObservableProperty]
        private string _carLine;

        [ObservableProperty]
        public string _rightLever;

        [ObservableProperty]
        public string _leftLever;

        [ObservableProperty]
        public string _sRCSwitch;

        [ObservableProperty]
        public string _pCB;

        [ObservableProperty]
        public string _sRC;

        public Module NoneObservableModel() => new()
        {
            Variant = _variant,
            CarLine = _carLine,
            RightLever = _rightLever,
            LeftLever = _leftLever,
            SRCSwitch = _sRCSwitch,
            PCB = _pCB,
            SRC = _sRC,
        };

    }
}
