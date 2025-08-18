using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using PartModelVis.Core.Models.ObservableDTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.ViewModels
{

    /// <summary>
    /// ViewModel which shows the variant and the car line info
    /// </summary>
    public partial class ModuleDescriptionViewModel : ObservableObject
    {
        [ObservableProperty]
        private ModuleDTO _module;
        
        public ModuleDescriptionViewModel(ModuleDTO module)
        {
            _module = module;
        }
    }
}
