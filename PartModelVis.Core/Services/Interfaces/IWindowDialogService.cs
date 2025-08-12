using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PartModelVis.Core.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWindowDialogService
    {

        /// <summary>
        /// ShowDialog display's new dialog window.
        /// </summary>
        /// <typeparam name="TView">The view model.</typeparam>
        public void ShowDialog<TView>() where TView : Window;
        /// <summary>
        /// ShowDialog display's new dialog window
        /// </summary>
        /// <typeparam name="TView">The view model.</typeparam>
        /// <typeparam name="TViewModel">The view model.</typeparam>
        public void ShowDialog<TView, TViewModel>()
            where TViewModel : ObservableObject
            where TView: Window;

    }
}
