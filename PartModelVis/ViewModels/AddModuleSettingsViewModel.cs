using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PartModelVis.Core.Configurations;
using PartModelVis.Core.Handlers;
using PartModelVis.Core.Handlers.Exceptions;
using PartModelVis.Core.Helper;
using PartModelVis.Core.Models.ObservableDTO;
using PartModelVis.Core.Services.Interfaces;
using PartModelVis.Views.PopUps;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PartModelVis.ViewModels
{
    public partial class AddModuleSettingsViewModel:ObservableObject 
    {

        [ObservableProperty]
        private ModuleConfigurationDTO _moduleConfiguration;

        //Services
        private IWindowDialogService _windowService;

        public AddModuleSettingsViewModel(IWindowDialogService windowService,
                                 ModuleConfigurationDTO moduleConfiguration)
        {
            _windowService = windowService;

            _moduleConfiguration = moduleConfiguration;
        }

        [RelayCommand]
        private void StartVisual()
        {
            ChainExceptionHandler chainExceptionHandler = 
                new ChainExceptionHandler(
                    new FieldEmptyHandler(_moduleConfiguration.Variant) { MessageHandler = "Fill the textboxes!" },
                    new FieldEmptyHandler(_moduleConfiguration.InformationFile) { MessageHandler = "Fill the textboxes!" },
                    new FieldEmptyHandler(_moduleConfiguration.VisualFile) { MessageHandler = "Fill the textboxes!" },
                    new FileExistsHandler(_moduleConfiguration.InformationFile) { MessageHandler = $"The file \"{_moduleConfiguration.InformationFile}\" doesn't exist!"},
                    new FileExistsHandler(_moduleConfiguration.VisualFile) { MessageHandler = $"The file \"{_moduleConfiguration.VisualFile}\" doesn't exist!" }
                );

            if (chainExceptionHandler.CheckConditions() == false)
                return;

           

        }

        [RelayCommand]
        private void SetupVisual()
        {
            _windowService.ShowDialog<PartsVisualSettingsView, PartsVisualSettingsViewModel>();
        }

        [RelayCommand]
        private void CreateModule()
        {
            _windowService.ShowDialog<ModuleSettingsView, ModuleSettingsViewModel>();
        }

        [RelayCommand]
        private void SelectInformationFilePath()
        {
            ModuleConfiguration.InformationFile = FileHelper.OpenFilePath();
        }

        [RelayCommand]
        private void SelectVisualFilePath()
        {
            ModuleConfiguration.VisualFile = FileHelper.OpenFilePath();
        }

    }
}
