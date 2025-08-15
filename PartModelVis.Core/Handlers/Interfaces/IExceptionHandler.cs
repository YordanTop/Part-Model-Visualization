using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Handlers.Interfaces
{
    public interface IExceptionHandler
    {
        public string MessageHandler { get; set; }

        public bool IsConditionValued();

        public void PopUpMessage();
    }
}
