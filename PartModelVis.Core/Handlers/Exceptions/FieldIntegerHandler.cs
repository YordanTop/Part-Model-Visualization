using PartModelVis.Core.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Handlers.Exceptions
{
    public class FieldIntegerHandler : IExceptionHandler
    {
        public string MessageHandler { get; set; }
        
        private string _fieldText;
        public FieldIntegerHandler(string fieldText)
        {
            _fieldText = fieldText;
        }

        public bool IsConditionValid()
        {
            if(int.TryParse(_fieldText, out int value))
            {
                return true;
            }
            return false;
        }

        public void PopUpMessage()
        {
            MessageBox.Show(MessageHandler, "Field exception!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
