using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PartModelVis.Core.Services;
using PartModelVis.Core.Services.Interfaces;
using PartModelVis.Views.PopUps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.ViewModels
{
    public partial class InfoSearcherViewModel:ObservableObject
    {
        //Services
        private readonly IWindowDialogService _windowService;
        public InfoSearcherViewModel(IWindowDialogService windowService)
        {
            _windowService = windowService;
        }

        /// <summary>
        /// Button command for showing a list of all module properties
        /// </summary>
        [RelayCommand]
        private void OpenModulePropertyList()
        {
            
        }

        /// <summary>
        /// Button command for opening the setting/config menu
        /// </summary>
        [RelayCommand]
        private void OpenSettings()
        {
            _windowService.ShowDialog<AddModuleSettingsView,AddModuleSettingsViewModel>();
        }
    }
}
