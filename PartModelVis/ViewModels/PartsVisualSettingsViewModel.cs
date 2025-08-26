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

        [ObservableProperty]
        private ImageAttributesViewModel _imageAttributesViewModel;

        private Point _originalSelectedImagePoint;

        private Point _originalSelectedMousePoint;

        private Canvas _canvas;



        //Services
        private IModuleVisualizeService _visualizeService;

        public PartsVisualSettingsViewModel(ModuleConfigurationDTO moduleDTO,
                                            ImageAttributesViewModel imageAttributesViewModel,
                                            ModulePartImage partImage,
                                            IModuleExtractService moduleExtractService,
                                            IModuleVisualizeService visualizeService)
        {
            _visualizeService = visualizeService;

            ImageAttributesViewModel = imageAttributesViewModel;

            PartImage = partImage;

            moduleExtractService.FileName = moduleDTO.InformationFile;

            var module = moduleExtractService.ExtractModule(moduleDTO.Variant, moduleDTO.CarLine);
            var imageCollection = _visualizeService.ImageCollectionInstance(module);

            PartImages = new ObservableCollection<ModulePartImage>(imageCollection);

        }

        [RelayCommand]
        private void SelectImage(MouseEventArgs mouseEvent)
        {
                if (mouseEvent.Source is System.Windows.FrameworkElement element &&
                    element.DataContext is ModulePartImage image)
                {
                    PartImage = image;

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

                if (mouseEvent.LeftButton == MouseButtonState.Pressed &&
                    Keyboard.IsKeyDown(Key.LeftCtrl) &&
                    mouseEvent.Source is FrameworkElement element)
                {
                    var currentMousePoint = mouseEvent.GetPosition(_canvas);

                    var newDragPosition = MouseHelper.DragImage(_originalSelectedImagePoint, currentMousePoint, _originalSelectedMousePoint);

                    PartImage.PositionX = newDragPosition.X;
                    PartImage.PositionY = newDragPosition.Y;
                }
            
        }

        [RelayCommand]
        private void RotateImage(MouseEventArgs mouseEvent)
        {
            if (PartImage == null)
                return;


            if (mouseEvent.LeftButton == MouseButtonState.Pressed &&
                Keyboard.IsKeyDown(Key.LeftShift)
                && mouseEvent.Source is FrameworkElement element)
            {
                var originalRotation = PartImage.Rotation;

                var currentMousePoint = mouseEvent.GetPosition(_canvas);

                var imageCenterPoint = new Point((PartImage.Width / 2), (PartImage.Height / 2));

                float rotationSpeed = 0.25f;

                PartImage.Rotation = MouseHelper.RotateImage(originalRotation, currentMousePoint, imageCenterPoint,rotationSpeed);

            }

        }

        [RelayCommand]
        private void ScaleImage(MouseEventArgs mouseEvent)
        {
            if (PartImage == null)
                return;


            if (mouseEvent.LeftButton == MouseButtonState.Pressed &&
            Keyboard.IsKeyDown(Key.LeftCtrl)
            && mouseEvent.Source is FrameworkElement element)
            {

               

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
