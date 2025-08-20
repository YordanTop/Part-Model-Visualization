using PartModelVis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Services.Interfaces
{
    public interface IModuleExtractService
    {
        /// <summary>
        /// The name of the extracting file.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Extract the content about the module from the file.
        /// </summary>
        /// <param name="moduleVariant">The variant of the module</param>
        /// <returns>Returns the content of the module</returns>
        public Module ExtractModule(string moduleVariant, string moduleCarLine);
    }
}
