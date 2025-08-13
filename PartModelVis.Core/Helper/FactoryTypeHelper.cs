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
        protected string _extansionFile { get; set; }
        /// <summary>
        /// Проверява типът на файла.
        /// </summary>
        /// <param name="extansion">типът на файла.</param>
        /// <returns>Резултата от самото сверяване.</returns>
        public bool CheckType(string extansion) => _extansionFile.Equals(extansion);

    }
}
