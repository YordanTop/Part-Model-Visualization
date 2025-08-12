using PartModelVis.Core.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Handlers.Exceptions
{
    public class FileEmptyHandler : IExceptionHandler
    {
        public string MessageHandler { get; set; }

        private string _filePath;

        public FileEmptyHandler(string filePath)
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

    }
}
