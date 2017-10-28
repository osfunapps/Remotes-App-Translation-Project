﻿using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Remotes_App_Translation_Project
{
    internal class FilesExlorerManager
    {
        private string FOLDER_TRASNLATIONS = "\\Translations";

        public Dictionary<string, string> ExtractFilesNamesList()
        {
            var currentFolder = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + FOLDER_TRASNLATIONS;
            Dictionary<string, string> languagesDict = new Dictionary<string, string>();
            string[] files = Directory.GetFiles(currentFolder);

            foreach (var languageFilePath in files)
            {
                int startIdx = languageFilePath.LastIndexOf("\\") + 1;
                int endIdx = languageFilePath.LastIndexOf(".");
                int length = endIdx - startIdx;
                string languageFileName = languageFilePath.Substring(startIdx, length);
                languagesDict.Add(languageFileName, languageFilePath);
            }
            return languagesDict;
        }
    }
}