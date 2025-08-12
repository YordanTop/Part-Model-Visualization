using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using PartModelVis.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace PartModelVis.Core.Services
{
    public class WindowService:IWindowDialogService
    {
        private readonly IServiceProvider _serviceProvider;

        public WindowService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public void ShowDialog<TView>() 
            where TView: Window
        {
            var _window = _serviceProvider.GetRequiredService<TView>();

            _window.ShowDialog();
        }

        public void ShowDialog<TView, TViewModel>() 
            where TViewModel : ObservableObject
            where TView: Window
        {
            var vm = _serviceProvider.GetRequiredService<TViewModel>() as ObservableObject;
            var view = _serviceProvider.GetRequiredService<TView>() as Window;

           
            view.DataContext = vm;
            view.ShowDialog();
        }
    }
}
