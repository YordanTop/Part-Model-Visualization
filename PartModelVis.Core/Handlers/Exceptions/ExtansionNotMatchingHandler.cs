using PartModelVis.Core.Handlers.Interfaces;
using PartModelVis.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Handlers.Exceptions
{
    public class ExtansionNotMatchingHandler : IExceptionHandler
    {
        public string MessageHandler { get; set; }

        private FileExtantion _extansion;
        public ExtansionNotMatchingHandler(FileExtantion extansion)
        {
            _extansion = extansion;
        }


        public void PopUpMessage()
        {
            MessageBox.Show(MessageHandler, "Extansion exception!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public bool IsConditionValid()
        {
            throw new NotImplementedException();
        }
    }
}
