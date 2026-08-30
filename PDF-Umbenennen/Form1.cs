using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraPdfViewer;

namespace PDF_Umbenennen
{
    public partial class Form1 : Form
    {
        private readonly PdfFilePreviewManager previewManager;
        private string? selectedFolder;
        private string? currentOriginalPath;
        private bool isRefreshingList;

        private bool lastFolderRestored;

        public Form1()
        {
            InitializeComponent();
            this.previewManager = new PdfFilePreviewManager(this.pdfViewer);
        }

        private void ButtonSelectFolder_Click(object? sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Verzeichnis mit PDF-Dateien wählen";
                dialog.UseDescriptionForTitle = true;
                if (!string.IsNullOrEmpty(this.selectedFolder) && Directory.Exists(this.selectedFolder))
                {
                    dialog.SelectedPath = this.selectedFolder;
                }

                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                this.selectedFolder = dialog.SelectedPath;
                this.textBoxFolder.Text = this.selectedFolder;
                LastFolderStore.Save(this.selectedFolder);
                LoadPdfList(null);
            }
        }

        private void ListBoxFiles_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (this.isRefreshingList)
            {
                return;
            }

            PdfListItem? item = this.listBoxFiles.SelectedItem as PdfListItem;
            if (item == null)
            {
                ClearPreview();
                return;
            }

            OpenOriginalAsTempCopy(item.FullPath);
        }

        private void ButtonRename_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.currentOriginalPath))
            {
                SetStatus("Bitte zuerst eine PDF-Datei in der Liste auswählen.");
                return;
            }

            string originalPathBeforeRename = this.currentOriginalPath;
            string newFileName;
            try
            {
                newFileName = PdfFileRenamer.BuildPdfFileName(this.textBoxNewName.Text);
            }
            catch (Exception ex)
            {
                SetStatus(ex.Message);
                return;
            }

            try
            {
                string newPath = PdfFileRenamer.RenameOriginal(originalPathBeforeRename, newFileName);
                SetStatus("Datei umbenannt: " + Path.GetFileName(newPath));
                LoadPdfList(newPath);
            }
            catch (Exception ex)
            {
                SetStatus("Umbenennen abgebrochen. Original bleibt unverändert. " + ex.Message);
                if (File.Exists(originalPathBeforeRename))
                {
                    this.currentOriginalPath = originalPathBeforeRename;
                }
            }
        }

        private void Form1_Shown(object? sender, EventArgs e)
        {
            RestoreLastFolder();
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            this.previewManager.CloseAndDeleteTemp();
        }

        private void RestoreLastFolder()
        {
            if (this.lastFolderRestored)
            {
                return;
            }

            this.lastFolderRestored = true;

            string? lastFolder = LastFolderStore.TryLoadExistingDirectory();
            if (lastFolder == null)
            {
                return;
            }

            this.selectedFolder = lastFolder;
            this.textBoxFolder.Text = lastFolder;
            LoadPdfList(null);
        }

        private void ButtonZoomWidth_Click(object? sender, EventArgs e)
        {
            if (!HasOpenDocument())
            {
                return;
            }

            this.pdfViewer.ZoomMode = PdfZoomMode.FitToWidth;
        }

        private void ButtonZoomHeight_Click(object? sender, EventArgs e)
        {
            if (!HasOpenDocument())
            {
                return;
            }

            int pageNumber = this.pdfViewer.CurrentPageNumber;
            if (pageNumber < 1)
            {
                SetStatus("Keine Seite zum Skalieren.");
                return;
            }

            SizeF currentPageSize = this.pdfViewer.GetPageSize(pageNumber);
            if (currentPageSize.Height <= 0f)
            {
                SetStatus("Seitenhöhe konnte nicht ermittelt werden.");
                return;
            }

            const float defaultPdfViewerDpi = 110f;
            const float topBottomOffset = 40f;
            float pageHeightPixel = currentPageSize.Height * defaultPdfViewerDpi;
            float availableHeight = (float)this.pdfViewer.ClientSize.Height - topBottomOffset;
            if (availableHeight <= 0f)
            {
                availableHeight = (float)this.pdfViewer.ClientSize.Height;
            }

            float zoomFactor = availableHeight / pageHeightPixel * 100f;
            if (zoomFactor < this.pdfViewer.MinZoomFactor)
            {
                zoomFactor = this.pdfViewer.MinZoomFactor;
            }

            if (zoomFactor > this.pdfViewer.MaxZoomFactor)
            {
                zoomFactor = this.pdfViewer.MaxZoomFactor;
            }

            this.pdfViewer.ZoomMode = PdfZoomMode.Custom;
            this.pdfViewer.ZoomFactor = zoomFactor;
        }

        private void ButtonZoomPage_Click(object? sender, EventArgs e)
        {
            if (!HasOpenDocument())
            {
                return;
            }

            this.pdfViewer.ZoomMode = PdfZoomMode.PageLevel;
        }

        private bool HasOpenDocument()
        {
            if (this.pdfViewer.PageCount > 0)
            {
                return true;
            }

            SetStatus("Bitte zuerst eine PDF-Datei öffnen.");
            return false;
        }

        private void LoadPdfList(string? selectPath)
        {
            this.isRefreshingList = true;
            try
            {
                this.previewManager.CloseAndDeleteTemp();
                this.currentOriginalPath = null;
                this.listBoxFiles.Items.Clear();

                if (string.IsNullOrEmpty(this.selectedFolder) || !Directory.Exists(this.selectedFolder))
                {
                    this.textBoxNewName.Clear();
                    SetStatus("Das gewählte Verzeichnis existiert nicht.");
                    return;
                }

                string[] files = Directory.GetFiles(this.selectedFolder, "*.pdf", SearchOption.TopDirectoryOnly);
                Array.Sort(files, StringComparer.CurrentCultureIgnoreCase);

                int selectIndex = -1;
                for (int i = 0; i < files.Length; i++)
                {
                    PdfListItem item = new PdfListItem(files[i]);
                    this.listBoxFiles.Items.Add(item);
                    if (!string.IsNullOrEmpty(selectPath) &&
                        string.Equals(files[i], selectPath, StringComparison.OrdinalIgnoreCase))
                    {
                        selectIndex = i;
                    }
                }

                SetStatus(files.Length.ToString() + " PDF-Datei(en) gefunden.");

                if (selectIndex >= 0)
                {
                    this.listBoxFiles.SelectedIndex = selectIndex;
                }
                else
                {
                    this.textBoxNewName.Clear();
                }
            }
            catch (Exception ex)
            {
                SetStatus("Verzeichnis konnte nicht gelesen werden: " + ex.Message);
            }
            finally
            {
                this.isRefreshingList = false;
            }

            if (this.listBoxFiles.SelectedItem is PdfListItem selected)
            {
                OpenOriginalAsTempCopy(selected.FullPath);
            }
        }

        private void OpenOriginalAsTempCopy(string originalPath)
        {
            try
            {
                this.previewManager.ShowCopy(originalPath);
                this.currentOriginalPath = originalPath;
                this.textBoxNewName.Text = Path.GetFileNameWithoutExtension(originalPath);
                SetStatus("Vorschau (Temp-Kopie): " + Path.GetFileName(originalPath));
            }
            catch (Exception ex)
            {
                this.currentOriginalPath = originalPath;
                this.textBoxNewName.Text = Path.GetFileNameWithoutExtension(originalPath);
                SetStatus("PDF konnte nicht geladen werden. Original bleibt unverändert. " + ex.Message);
            }
        }

        private void ClearPreview()
        {
            this.previewManager.CloseAndDeleteTemp();
            this.currentOriginalPath = null;
            this.textBoxNewName.Clear();
        }

        private void SetStatus(string message)
        {
            this.labelStatus.Text = message;
        }
    }
}
