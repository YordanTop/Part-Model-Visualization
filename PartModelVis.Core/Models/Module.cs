using PartModelVisualisation.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Models
{
    public class Module
    {
        /// <summary>
        /// Вариант.
        /// </summary>
        public string Variant { get; set; }

        /// <summary>
        /// Машината, от която е произведена.
        /// </summary>
        public string CarLine { get; set; }
        /// <summary>
        /// Дясна ръчка
        /// </summary>
        public string RightLever { get; set; }

        /// <summary>
        /// Лява касета
        /// </summary>
        public string LeftLever { get; set; }

        /// <summary>
        /// Контролер за спиралната касета
        /// </summary>
        public string SRCSwitch { get; set; }
        /// <summary>
        /// Платка.
        /// </summary>
        public string PCB { get; set; }
        /// <summary>
        /// Спирална касета.
        /// </summary>
        public string SRC { get; set; }

    }
}
