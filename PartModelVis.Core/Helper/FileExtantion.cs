using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Models
{
    public enum FileExtantion
    {
        [Description(".json")]
        JSON,
        [Description(".xml")]
        XML,
        [Description(".csv")]
        CSV
    }

    public static class FileExtantionFunctionality
    {
        /// <summary>
        /// Take the description of the <see cref="FileExtantion" />
        /// </summary>
        /// <param name="fileExtantion">extation of the file</param>
        /// <returns>extation of the file in string format</returns>
        public static string GetExtention(this FileExtantion fileExtantion)
        {
            var fieldType = fileExtantion.GetType().GetField(fileExtantion.ToString());

            if (Attribute.GetCustomAttribute(fieldType, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }

            return String.Empty;
        }
    }
}
