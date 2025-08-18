using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PartModelVis.Core.Configurations;
using PartModelVis.Core.Handlers.Exceptions;
using PartModelVis.Core.Models.ObservableDTO;
using PartModelVis.Core.Services.Interfaces;
using PartModelVis.Views.PopUps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        //Model 
        private ModuleConfigurationDTO _moduleConfiguration;

        //Services
        private IWindowDialogService _windowService;

        public MainViewModel(ModuleConfigurationDTO moduleConfiguration ,IWindowDialogService windowService, InfoSearcherViewModel infoSearcherViewModel, ModuleDescriptionViewModel moduleDescriptionViewModel, ModuleDisplayerViewModel moduleDisplayerViewModel)
        {
            _infoSearcherViewModel = infoSearcherViewModel;
            _moduleDescriptionViewModel = moduleDescriptionViewModel;
            _moduleDisplayerViewModel = moduleDisplayerViewModel;

            _moduleConfiguration = moduleConfiguration;

            _windowService = windowService;
        }

        [RelayCommand]
        private void VisualConfig()
        {

            if (isModuleLoaded())
                _windowService.ShowDialog<PartsVisualSettingsView, PartsVisualSettingsViewModel>();
        }


        [RelayCommand]
        private void ModuleConfig()
        {
            if(isModuleLoaded())
                _windowService.ShowDialog<ModuleSettingsView, ModuleSettingsViewModel>();
        }


        private bool isModuleLoaded()
        {
            ModuleLoadHandler loadHandler = new ModuleLoadHandler(_moduleConfiguration.ToModel.IsModuleLoaded);

            loadHandler.MessageHandler = "The module must be added before configuration.";
            bool isLoaded = loadHandler.IsConditionValid();

            if (!isLoaded)
            {
                loadHandler.PopUpMessage();
            }

            return isLoaded;
        }
    }
}
