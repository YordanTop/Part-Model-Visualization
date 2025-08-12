using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PartModelVis.Core.Services.Interfaces;
using PartModelVis.Views.PopUps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.ViewModels
{

    /// <summary>
    /// The main ViewModel which show every view models for the main view.
    /// </summary>
    public partial class MainViewModel:ObservableObject
    {
        [ObservableProperty]
        public InfoSearcherViewModel _infoSearcherViewModel;

        [ObservableProperty]
        public ModuleDescriptionViewModel _moduleDescriptionViewModel;

        [ObservableProperty]
        public ModuleDisplayerViewModel _moduleDisplayerViewModel;

        //Services
        private IWindowDialogService _windowService;

        public MainViewModel(IWindowDialogService windowService, InfoSearcherViewModel infoSearcherViewModel, ModuleDescriptionViewModel moduleDescriptionViewModel, ModuleDisplayerViewModel moduleDisplayerViewModel)
        {
            _infoSearcherViewModel = infoSearcherViewModel;
            _moduleDescriptionViewModel = moduleDescriptionViewModel;
            _moduleDisplayerViewModel = moduleDisplayerViewModel;

            _windowService = windowService;
        }

        [RelayCommand]
        private void VisualConfig()
        {
            _windowService.ShowDialog<PartsVisualSettingsView, PartsVisualSettingsViewModel>();
        }

        [RelayCommand]
        private void ModuleConfig()
        {
            _windowService.ShowDialog<ModuleSettingsView, ModuleSettingsViewModel>();
        }
    }
}
