using PartModelVis.Core.ModuleExporters.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Helper
{
    public abstract class FactoryHelper<FactoryType, ElementType>
    {
        protected IList<FactoryType> ElementTypeList { get; set; }

        public abstract ElementType CreateType(FileStream file, string extansion);
    }
}
