using PartModelVis.Core.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Handlers.Exceptions
{
    public class FileExistsHandler : IExceptionHandler
    {
        public string MessageHandler { get; set;  }

        private string _filePath;
        
        public FileExistsHandler(string filePath)
        {
            _filePath = filePath;
        }

        public bool IsConditionValid()
        {
            if (!File.Exists(_filePath))
            {
                return false;
            }
            return true;

        }

        public void PopUpMessage()
        {
            MessageBox.Show(MessageHandler,"File exception!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
