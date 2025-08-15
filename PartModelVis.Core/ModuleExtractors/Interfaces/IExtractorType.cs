using PartModelVis.Core.Models;
using PartModelVisualisation.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.ModuleExtractors.Interfaces
{
    /// <summary>
    /// IModuleExtractor има за цел да извлича данни за форматиране
    /// </summary>
    public interface IExtractorType
    {
        /// <summary>
        /// Извличане на най-съществаната информация за варианта на модула.
        /// </summary>
        /// <param name="moduleVariant">Варианта на модела.</param>
        /// <returns>Връща инфорамация за модула./returns>
        public Module ExtractModule(string moduleVariant);

    }
}
