using System;
using System.IO;
using DevExpress.XtraPdfViewer;

namespace PDF_Umbenennen
{
    internal sealed class PdfFilePreviewManager : IDisposable
    {
        private readonly PdfViewer pdfViewer;
        private readonly string tempDirectory;
        private string? tempFilePath;

        public PdfFilePreviewManager(PdfViewer pdfViewer)
        {
            this.pdfViewer = pdfViewer;
            this.tempDirectory = Path.Combine(Path.GetTempPath(), "PDF-Umbenennen");
            Directory.CreateDirectory(this.tempDirectory);
            this.pdfViewer.DetachStreamAfterLoadComplete = true;
        }

        public void ShowCopy(string originalPdfPath)
        {
            CloseAndDeleteTemp();

            string newTempPath = Path.Combine(this.tempDirectory, Guid.NewGuid().ToString("N") + ".pdf");
            File.Copy(originalPdfPath, newTempPath, false);

            try
            {
                this.pdfViewer.LoadDocument(newTempPath);
                this.tempFilePath = newTempPath;
            }
            catch
            {
                TryDeleteFile(newTempPath);
                throw;
            }
        }

        public void CloseAndDeleteTemp()
        {
            try
            {
                this.pdfViewer.CloseDocument();
            }
            catch (Exception)
            {
            }

            if (!string.IsNullOrEmpty(this.tempFilePath))
            {
                TryDeleteFile(this.tempFilePath);
                this.tempFilePath = null;
            }
        }

        public void Dispose()
        {
            CloseAndDeleteTemp();
        }

        private static void TryDeleteFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
