using System;
using System.IO;

namespace PDF_Umbenennen
{
    internal static class LastFolderStore
    {
        private static string GetSettingsDirectory()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "PDF-Umbenennen");
        }

        private static string GetFilePath()
        {
            return Path.Combine(GetSettingsDirectory(), "last-folder.txt");
        }

        public static void Save(string folderPath)
        {
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                return;
            }

            try
            {
                Directory.CreateDirectory(GetSettingsDirectory());
                File.WriteAllText(GetFilePath(), folderPath);
            }
            catch (Exception)
            {
            }
        }

        public static string? TryLoadExistingDirectory()
        {
            try
            {
                string settingsFile = GetFilePath();
                if (!File.Exists(settingsFile))
                {
                    return null;
                }

                string folderPath = File.ReadAllText(settingsFile).Trim();
                if (string.IsNullOrEmpty(folderPath) || !Directory.Exists(folderPath))
                {
                    return null;
                }

                return folderPath;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
