using PartModelVis.Core.Configurations;
using PartModelVis.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartModelVis.Core.Helper
{
    public static class FileHelper
    {
        public static FileStream FetchFile(string filePath) => File.Open(filePath, FileMode.Open);

        public static string GetExtansion(FileStream file) => Path.GetExtension(file.Name);

        public static string? SelectingFilePath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Select a file",
                Filter = "All file (*.*)|*.*",
                Multiselect = false
            };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    return openFileDialog.FileName;

            return null;
        }
    }
}
