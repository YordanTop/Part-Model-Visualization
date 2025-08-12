using PartModelVis.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for CreateModelSettingsView.xaml
    /// </summary>
    public partial class ModuleSettingsView : Window
    {
        public ModuleSettingsView(ModuleSettingsViewModel vm)
        {
            InitializeComponent();

            DataContext = vm;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ModuleDataGrid.Items is IEditableCollectionView editableCollectionView)
            {
                if (editableCollectionView.IsAddingNew)
                {
                    editableCollectionView.CancelNew();
                }

                if (editableCollectionView.IsEditingItem)
                {
                    editableCollectionView.CancelEdit();
                }
            }
        }
    }
}
