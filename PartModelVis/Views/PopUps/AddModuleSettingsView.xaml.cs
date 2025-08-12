using PartModelVis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PartModelVis.Views.PopUps
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class AddModuleSettingsView : Window
    {
        public AddModuleSettingsView(AddModuleSettingsViewModel vm)
        {
            InitializeComponent();

            DataContext = vm;
        }
    }
}
