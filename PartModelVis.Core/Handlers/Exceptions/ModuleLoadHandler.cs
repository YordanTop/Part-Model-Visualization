using PartModelVis.Core.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Handlers.Exceptions
{
    public class ModuleLoadHandler : IExceptionHandler
    {
        public string MessageHandler { get; set; }

        private bool _isLoaded;
        public ModuleLoadHandler(bool isLoaded)
        {
            _isLoaded = isLoaded;
        }

        public bool IsConditionValid()
        {
            return _isLoaded;
        }

        public void PopUpMessage()
        {
            MessageBox.Show(MessageHandler, "Module Loading exception!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
