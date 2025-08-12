using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace PartModelVisualisation.Core.Models
{
    public class ModuleAlternativeProperty
    {
        private string _name;
        /// <summary>
        /// Име на стойността от дадения вариант
        /// </summary>
        public string Name { get { return _name; }
            set 
            {
                if (value == null || value.Equals(String.Empty))
                    _name = "Not named column";
                else
                    _name = value;  
            }
        }


        /// <summary>
        /// The name base 
        /// </summary>
        public string FilePropertyName { get; set; }
        
        /// <summary>
        /// Значение на стойността от дадения вариант
        /// </summary>
        public string? Description { get; set; }

        public string? PicturePath { get; set; }

    }
}
