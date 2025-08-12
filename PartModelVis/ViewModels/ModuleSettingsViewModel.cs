using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PartModelVis.Core.Models.ObservableDTO;
using PartModelVisualisation.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PartModelVis.ViewModels
{
    public partial class ModuleSettingsViewModel:ObservableObject
    {

        [ObservableProperty]
        private ModuleDTO _module;

        [ObservableProperty]
        private ObservableCollection<ModuleAlternativePropertyTransactionDTO> _moduleAlternativeProperties;




        public ModuleSettingsViewModel(ModuleDTO module, ObservableCollection<ModuleAlternativePropertyTransactionDTO> moduleAlternativeProperties)
        {
            _module = module;
            _moduleAlternativeProperties = moduleAlternativeProperties;
            
        }

        [RelayCommand]
        private void SaveChanges()
        {
           
        }

    }
}
