using PartModelVis.Core.Handlers.Interfaces;
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

        public bool IsConditionValued()
        {
            throw new NotImplementedException();
        }
    }
}
