using PartModelVis.Core.ModuleExporters.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Helper
{
    public abstract class FactoryTypeHelper
    {
        /// <summary>
        /// The format extansion.
        /// </summary>
        protected string _extansionFile { get; set; }
        /// <summary>
        /// Checks the extansion of the file.
        /// </summary>
        /// <param name="extansion">extansion type.</param>
        /// <returns>return if the extansion is form a given type.</returns>
        public bool CheckType(string extansion) => _extansionFile.Equals(extansion);

    }
}
