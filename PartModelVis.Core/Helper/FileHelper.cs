using PartModelVis.Core.Configurations;
using PartModelVis.Core.Handlers.Exceptions;
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
        public static FileStream FetchFile(string filePath)
        {
            FileExistsHandler fileHandler = new FileExistsHandler(filePath);

            if (!fileHandler.IsConditionValid())
                throw new FileNotFoundException($"the file format was not declare!");
            
            return File.Open(filePath, FileMode.Open);
        }

        public static string GetExtansion(string filePath)
        {
            FileExistsHandler fileHandler = new FileExistsHandler(filePath);

            if(!fileHandler.IsConditionValid())
                throw new FileNotFoundException($"the file format was not declare!");

            return Path.GetExtension(filePath);
        }
        public static string? OpenFilePath()
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

        public static string? SaveFilePath()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = "Save As",
                Filter = "All file (*.*)|*.*",
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                return saveFileDialog.FileName;

            return null;
        }

    }
}
