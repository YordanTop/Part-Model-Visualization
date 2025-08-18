using CommunityToolkit.Mvvm.ComponentModel;
using PartModelVis.Core.Configurations;
using PartModelVisualisation.Core.Models;
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
        private List<ModuleAlternativeProperty> _modulesProperties;

        public Module ToModel => new()
        {
            Variant = _variant,
            CarLine = _carLine,
            ModuleProperties = _modulesProperties
        };

    }
}
