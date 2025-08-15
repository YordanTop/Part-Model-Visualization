using PartModelVis.Core.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Handlers.Exceptions
{
    public class FieldEmptyHandler : IExceptionHandler
    {
        public string MessageHandler { get; set; }

        private string _filePath;

        public FieldEmptyHandler(string filePath)
        {
            _filePath = filePath;
        }

        public bool IsConditionValued()
        {
            if (string.IsNullOrEmpty(_filePath))
            {
                return false;
            }
            return true;
        }

        public void PopUpMessage()
        {
            MessageBox.Show(MessageHandler, "Field exception!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
