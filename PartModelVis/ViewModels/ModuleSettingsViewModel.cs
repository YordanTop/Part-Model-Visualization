using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    public partial class ModuleSettingsViewModel:ObservableObject
    {

        [ObservableProperty]
        private Module _module;

        [ObservableProperty]
        private ObservableCollection<ModuleAlternativePropertyTransactionDTO> _moduleAlternativeProperties;

        //Services
        private IModuleExportService _moduleExportService;


        public ModuleSettingsViewModel(Module module, IModuleExportService moduleExportSerivce, ObservableCollection<ModuleAlternativePropertyTransactionDTO> moduleAlternativeProperties)
        {
            _module = module;

            _moduleExportService = moduleExportSerivce;

            _moduleAlternativeProperties = moduleAlternativeProperties;
            
        }

        [RelayCommand]
        private void SaveChanges()
        {
            _module.ModuleProperties = new List<ModuleAlternativeProperty>();
            foreach (var item in _moduleAlternativeProperties)
            {
                _module.ModuleProperties.Add(item.ToModel());
            }

            _moduleExportService.FileName = FileHelper.SaveFilePath();
            _moduleExportService.SaveChanges(_module);
        }

    }
}
