using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.ModuleExtractors.Interfaces
{
    /// <summary>
    /// IExtractorTypeProvider има за цел да създава различни типове екстрактори
    /// </summary>
    public abstract class ExtractorTypeFactory
    {
        protected string _extansionFile { get; set; }
        /// <summary>
        /// Проверява типът на файла.
        /// </summary>
        /// <param name="extansion">типът на файла.</param>
        /// <returns>Резултата от самото сверяване.</returns>
        public bool CheckType(string extansion) => _extansionFile.Equals(extansion);

        /// <summary>
        /// Създаване на инстанция от дадения тип.
        /// </summary>
        /// <param name="file">файла</param>
        /// <returns></returns>
        public abstract IExtractorType CreateExtractor(FileStream file);


    }
}
