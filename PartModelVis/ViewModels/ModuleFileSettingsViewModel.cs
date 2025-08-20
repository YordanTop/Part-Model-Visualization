using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PartModelVis.Core.Configurations;
using PartModelVis.Core.Helper;
using PartModelVis.Core.Models;
using PartModelVis.Core.Models.ObservableDTO;
using PartModelVis.Core.Services;
using PartModelVis.Core.Services.Interfaces;
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
    public partial class ModuleFileSettingsViewModel:ObservableObject
    {
        
        [ObservableProperty]
        private ObservableCollection<ModuleAlternativePropertyTransactionDTO> _moduleAlternativeProperties;

        private ModuleConfigurationDTO _moduleConfigurationDTO;

        //Model
        private Module _module;
        //Services
        private IModuleExportService _moduleExportService;


        public ModuleFileSettingsViewModel(ModuleDTO moduleDTO,
                                           ModuleConfigurationDTO moduleConfigurationDTO,
                                           IModuleExportService moduleExportSerivce,
                                           ObservableCollection<ModuleAlternativePropertyTransactionDTO> moduleAlternativeProperties)
        {
            _module = moduleDTO.ToModel;

            _moduleConfigurationDTO = moduleConfigurationDTO;

            _moduleExportService = moduleExportSerivce;

            _moduleAlternativeProperties = moduleAlternativeProperties;
            
        }

        [RelayCommand]
        private void SaveChanges()
        {
            UpdateModuleProperties(_moduleConfigurationDTO.ToModel);
            HandleFileExport(_module);
            UpdateInformationFile();
        }


        private void UpdateModuleProperties(ModuleConfiguration module)
        {

            _module.Variant = module.Variant;

            _module.CarLine = module.CarLine;

            _module.ModuleProperties = _moduleAlternativeProperties
                .Select(item => item.ToModel)
                .ToList();

        }

        private void HandleFileExport(Module module)
        {
            _moduleExportService.FileName = FileHelper.SaveFilePath();

            if (!string.IsNullOrEmpty(_moduleExportService.FileName))
            {
                _moduleExportService.SaveChanges(module);
            }
        }

        private void UpdateInformationFile()
        {
            _moduleConfigurationDTO.InformationFile = _moduleExportService.FileName;
        }

    }
}
