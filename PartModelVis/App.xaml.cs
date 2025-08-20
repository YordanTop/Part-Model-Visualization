using Microsoft.Extensions.DependencyInjection;
using PartModelVis.Core.Configurations;
using PartModelVis.Core.Models;
using PartModelVis.Core.Models.ObservableDTO;
using PartModelVis.Core.Services;
using PartModelVis.Core.Services.Interfaces;
using PartModelVis.ViewModels;
using PartModelVis.Views;
using PartModelVis.Views.PopUps;
using PartModelVisualisation.Core.Models;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace PartModelVis
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {

            var services = new ServiceCollection();

            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();

        }



        private void ConfigureServices(IServiceCollection services)
        {

            //Services

            services.AddTransient<IWindowDialogService,WindowService>();
            services.AddTransient<IModuleExportService, ModuleExportService>();
            services.AddTransient<IModuleExtractService, ModuleExtractService>();
            services.AddTransient<IModuleVisualizeService, ModuleVisualizeService>();

            //Models
            services.AddSingleton<Module>();

            //Model DTOs
            services.AddSingleton<ModuleDTO>();
            services.AddSingleton<ModuleConfigurationDTO>();
            
            services.AddTransient<ObservableCollection<ModuleAlternativePropertyTransactionDTO>>(provider =>
            {
                // DataGrid configuration setup
                return new ObservableCollection<ModuleAlternativePropertyTransactionDTO>() {
                new ModuleAlternativePropertyTransactionDTO(){Name = "RightLever", FilePropertyName = "proj_rightLever"},
                new ModuleAlternativePropertyTransactionDTO(){Name = "LeftLever", FilePropertyName = "proj_leftLever"},
                new ModuleAlternativePropertyTransactionDTO(){Name = "PCB", FilePropertyName = "proj_pcb"},
                new ModuleAlternativePropertyTransactionDTO(){Name = "SRC", FilePropertyName = "proj_src"},
                new ModuleAlternativePropertyTransactionDTO(){Name = "SRCSwitch", FilePropertyName = "proj_srcSwitch" } 
                };
            });


            //ViewModels

            //Main Window
            services.AddSingleton<InfoSearcherViewModel>();
            services.AddSingleton<ModuleDescriptionViewModel>();
            services.AddSingleton<ModuleDisplayerViewModel>();
            services.AddSingleton<MainViewModel>();

            //Pop ups
            services.AddTransient<AddModuleSettingsViewModel>();
            services.AddTransient<ModuleFileSettingsViewModel>();
            services.AddTransient<PartsVisualSettingsViewModel>();

            //Views

            //Main Window
            services.AddSingleton<InfoSearcherView>();
            services.AddSingleton<ModuleDescriptionView>();
            services.AddSingleton<ModuleDisplayerView>();
            services.AddSingleton<MainWindow>();

            //Pop ups
            services.AddTransient<AddModuleSettingsView>();
            services.AddTransient<ModuleSettingsView>();
            services.AddTransient<PartsVisualSettingsView>();
        }




        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();

            mainWindow.Show();

        }
    }

}
