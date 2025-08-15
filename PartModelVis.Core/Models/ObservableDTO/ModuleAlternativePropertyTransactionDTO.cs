using PartModelVisualisation.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Models.ObservableDTO
{
    public class ModuleAlternativePropertyTransactionDTO:IEditableObject
    {
        private string _name;
        /// <summary>
        /// Име на стойността от дадения вариант
        /// </summary>
        public string Name
        {
            get { return _name; }
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


        private ModuleAlternativePropertyTransactionDTO _backUp;

        public void BeginEdit()
        {
            _backUp = (ModuleAlternativePropertyTransactionDTO)MemberwiseClone();
        }

        public void CancelEdit()
        {
            if (_backUp != null)
            {
                Name = _backUp.Name;
                FilePropertyName = _backUp.FilePropertyName;
                Description = _backUp.Description;
                PicturePath = _backUp.PicturePath;
                _backUp = null;
            }
        }

        public void EndEdit()
        {
            _backUp = null;
        }

        public ModuleAlternativeProperty ToModel() => new()
        {
            Name = this.Name,
            FilePropertyName = this.FilePropertyName,
            Description = this.Description,
            PicturePath = this.PicturePath,
        };
    }
}
