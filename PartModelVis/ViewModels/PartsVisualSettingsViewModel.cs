using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PartModelVis.Core.Models;
using PartModelVis.Core.Models.ObservableDTO;
using PartModelVis.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PartModelVis.ViewModels
{
    public partial class PartsVisualSettingsViewModel:ObservableObject
    {

        [ObservableProperty]
        private ObservableCollection<ModulePartImage> _partImages;

        //Services
        private IModuleVisualizeService _visualizeService;
        private IModuleExtractService _moduleExtractService;

        public PartsVisualSettingsViewModel(ModuleConfigurationDTO moduleDTO, IModuleExtractService moduleExtractService, IModuleVisualizeService visualizeService)
        {
            _moduleExtractService = moduleExtractService;

            _moduleExtractService.FileName = moduleDTO.InformationFile;

            var module = _moduleExtractService.ExtractModule(moduleDTO.Variant);

            _visualizeService = visualizeService;

            var imageCollection = _visualizeService.ImageCollectionInstance(module);

            _partImages = new ObservableCollection<ModulePartImage>(imageCollection);
        }


        [RelayCommand]
        private void DragImage(ModulePartImage image)
        {
            _visualizeService.DragImage(image);
        }


        [RelayCommand]
        private void DropImage(ModulePartImage image)
        {
            _visualizeService.DropImage(image);
        }

        [RelayCommand]
        private void RotateImage(ModulePartImage image)
        {
            _visualizeService.RotateImage(image);
        }

        [RelayCommand]
        private void ScaleImage(ModulePartImage image)
        {
            _visualizeService.ScaleImage(image);
        }

    }
}
