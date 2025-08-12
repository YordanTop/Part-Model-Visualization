using PartModelVis.Core.ModuleExtractors.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.ModuleExtractors.Factory
{
    /// <summary>
    /// FactoryExtractors makes extractors based of the file format. 
    /// </summary>
    public class FactoryExtractors
    {

        private IList<ExtractorTypeFactory> _extractorList;

        public FactoryExtractors(IList<ExtractorTypeFactory> extractorList)
        {
            _extractorList = extractorList;
        }

        /// <summary>
        /// CreateExtractor makes an extractor based of it extansion.
        /// </summary>
        /// <param name="file">The information file of the model</param>
        /// <param name="extansion">The file format. <para>Example: json,xml,csv ...</para></param>
        /// <returns>Extractor that extracts a specific file format.</returns>
        /// <exception cref="NotSupportedException">if there is no extractor that transforms the data based of it's extansion it should return an error</exception>
        public IExtractorType CreateExtractor(FileStream file, string extansion)
        {

            var extractor = _extractorList.FirstOrDefault(extractor => extractor.CheckType(extansion));


            if (extractor == null)
            {
                throw new NotSupportedException($"This extansion '{extansion}' has no support!");
            }

            return extractor.CreateExtractor(file);
        }
    }
}
