using System;
using System.IO;

namespace PDF_Umbenennen
{
    internal static class PdfFileRenamer
    {
        public static string BuildPdfFileName(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                throw new ArgumentException("Der Dateiname darf nicht leer sein.");
            }

            string fileName = Path.GetFileName(userInput.Trim());
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("Der Dateiname ist ungültig.");
            }

            foreach (char invalidChar in Path.GetInvalidFileNameChars())
            {
                if (fileName.IndexOf(invalidChar) >= 0)
                {
                    throw new ArgumentException("Der Dateiname enthält ungültige Zeichen.");
                }
            }

            if (fileName == "." || fileName == "..")
            {
                throw new ArgumentException("Der Dateiname ist ungültig.");
            }

            if (fileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                return fileName;
            }

            return fileName + ".pdf";
        }

        public static string RenameOriginal(string originalFullPath, string newFileName)
        {
            if (string.IsNullOrWhiteSpace(originalFullPath))
            {
                throw new ArgumentException("Es ist keine Originaldatei ausgewählt.");
            }

            if (!File.Exists(originalFullPath))
            {
                throw new FileNotFoundException("Die Originaldatei wurde nicht gefunden. Es wurde nichts gelöscht.", originalFullPath);
            }

            string? directory = Path.GetDirectoryName(originalFullPath);
            if (string.IsNullOrEmpty(directory))
            {
                throw new InvalidOperationException("Das Verzeichnis der Originaldatei ist unbekannt.");
            }

            string targetPath = Path.Combine(directory, newFileName);
            if (string.Equals(Path.GetFullPath(originalFullPath), Path.GetFullPath(targetPath), StringComparison.OrdinalIgnoreCase))
            {
                return originalFullPath;
            }

            if (File.Exists(targetPath))
            {
                throw new IOException("Eine Datei mit diesem Namen existiert bereits. Die Originaldatei wurde nicht verändert.");
            }

            File.Move(originalFullPath, targetPath);

            if (!File.Exists(targetPath))
            {
                throw new IOException("Umbenennen fehlgeschlagen. Prüfen Sie, ob die Originaldatei noch vorhanden ist.");
            }

            return targetPath;
        }
    }
}
