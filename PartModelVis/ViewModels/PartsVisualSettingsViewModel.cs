using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PartModelVis.Core.Helper;
using PartModelVis.Core.Models;
using PartModelVis.Core.Models.ObservableDTO;
using PartModelVis.Core.Services;
using PartModelVis.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Point = System.Windows.Point;

namespace PartModelVis.ViewModels
{
    public partial class PartsVisualSettingsViewModel:ObservableObject
    {

        [ObservableProperty]
        private ObservableCollection<ModulePartImage> _partImages;

        [ObservableProperty]
        private ModulePartImage _partImage;

        private Point _originalSelectedImagePoint;

        private Point _originalSelectedMousePoint;

        private Canvas _canvas;



        //Services
        private IModuleVisualizeService _visualizeService;

        public PartsVisualSettingsViewModel(ModuleConfigurationDTO moduleDTO,
                                            IModuleExtractService moduleExtractService,
                                            IModuleVisualizeService visualizeService)
        {
            _visualizeService = visualizeService;

            moduleExtractService.FileName = moduleDTO.InformationFile;

            var module = moduleExtractService.ExtractModule(moduleDTO.Variant, moduleDTO.CarLine);
            var imageCollection = _visualizeService.ImageCollectionInstance(module);

            _partImages = new ObservableCollection<ModulePartImage>(imageCollection);

        }

        [RelayCommand]
        private void SelectImage(MouseEventArgs mouseEvent)
        {
            if (mouseEvent.Source is System.Windows.FrameworkElement element && 
                element.DataContext is  ModulePartImage image)
            {
                PartImage = image;
                PartImage.IsSelected = true;

                _canvas = FindParentCanvas(element);

                _originalSelectedMousePoint = mouseEvent.GetPosition(_canvas);

                _originalSelectedImagePoint = new Point(PartImage.PositionX, PartImage.PositionY);
            }
        }
        
        [RelayCommand]
        private void DragImage(MouseEventArgs mouseEvent)
        {
            if (PartImage == null)
                return;

            if (!PartImage.IsSelected)
                return;

            if (mouseEvent.LeftButton == MouseButtonState.Pressed && mouseEvent.Source is FrameworkElement element)
            {
                var currentMousePoint = mouseEvent.GetPosition(_canvas);

                var newDragPosition = MouseHelper.DragImage(_originalSelectedImagePoint, currentMousePoint, _originalSelectedMousePoint);

                PartImage.PositionX = newDragPosition.X;
                PartImage.PositionY = newDragPosition.Y;
            }
        }


        private Canvas FindParentCanvas(DependencyObject child)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);

            while (parent != null && !(parent is Canvas))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as Canvas;
        }

    }
}
