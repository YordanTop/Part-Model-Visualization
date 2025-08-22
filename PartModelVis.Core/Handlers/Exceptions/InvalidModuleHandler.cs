using PartModelVis.Core.Handlers.Interfaces;
using PartModelVis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Handlers.Exceptions
{
    public class InvalidModuleHandler : IExceptionHandler
    {
        public string MessageHandler { get; set; }

        private Module _module;

        private string _moduleVariantField;

        private string _moduleCarLineField;

        public InvalidModuleHandler(Module module,string moduleVariantField, string moduleCarLineField)
        {
            _module = module;
            _moduleVariantField = moduleVariantField;   
            _moduleCarLineField = moduleCarLineField;
        }

        public bool IsConditionValid()
        {
            if (!_module.Variant.Equals(_moduleVariantField))
                return false;

            if(!_module.CarLine.Equals(_moduleCarLineField))
                return false;

            return true;
        }

        public void PopUpMessage()
        {
            MessageBox.Show(MessageHandler, "Incorrenct module exception!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
