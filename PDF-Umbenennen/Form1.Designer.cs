#nullable enable

namespace PDF_Umbenennen
{
    partial class Form1
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.previewManager?.Dispose();
                if (this.components != null)
                {
                    this.components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        private void InitializeComponent()
        {
            this.tableLayoutRoot = new System.Windows.Forms.TableLayoutPanel();
            this.panelFolder = new System.Windows.Forms.Panel();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.tableLayoutViewer = new System.Windows.Forms.TableLayoutPanel();
            this.panelZoom = new System.Windows.Forms.Panel();
            this.buttonZoomWidth = new System.Windows.Forms.Button();
            this.buttonZoomHeight = new System.Windows.Forms.Button();
            this.buttonZoomPage = new System.Windows.Forms.Button();
            this.pdfViewer = new DevExpress.XtraPdfViewer.PdfViewer();
            this.panelRename = new System.Windows.Forms.Panel();
            this.labelFileName = new System.Windows.Forms.Label();
            this.textBoxNewName = new System.Windows.Forms.TextBox();
            this.buttonRename = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.tableLayoutRoot.SuspendLayout();
            this.panelFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.splitContainerMain).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tableLayoutViewer.SuspendLayout();
            this.panelZoom.SuspendLayout();
            this.panelRename.SuspendLayout();
            this.SuspendLayout();
            //
            // tableLayoutRoot
            //
            this.tableLayoutRoot.ColumnCount = 1;
            this.tableLayoutRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutRoot.Controls.Add(this.panelFolder, 0, 0);
            this.tableLayoutRoot.Controls.Add(this.splitContainerMain, 0, 1);
            this.tableLayoutRoot.Controls.Add(this.panelRename, 0, 2);
            this.tableLayoutRoot.Controls.Add(this.labelStatus, 0, 3);
            this.tableLayoutRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutRoot.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutRoot.Name = "tableLayoutRoot";
            this.tableLayoutRoot.RowCount = 4;
            this.tableLayoutRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutRoot.Size = new System.Drawing.Size(1200, 800);
            this.tableLayoutRoot.TabIndex = 0;
            //
            // panelFolder
            //
            this.panelFolder.Controls.Add(this.textBoxFolder);
            this.panelFolder.Controls.Add(this.buttonSelectFolder);
            this.panelFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFolder.Location = new System.Drawing.Point(3, 3);
            this.panelFolder.Name = "panelFolder";
            this.panelFolder.Padding = new System.Windows.Forms.Padding(4);
            this.panelFolder.Size = new System.Drawing.Size(1194, 42);
            this.panelFolder.TabIndex = 0;
            //
            // buttonSelectFolder
            //
            this.buttonSelectFolder.Location = new System.Drawing.Point(7, 7);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(160, 28);
            this.buttonSelectFolder.TabIndex = 0;
            this.buttonSelectFolder.Text = "Verzeichnis wählen";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.ButtonSelectFolder_Click);
            //
            // textBoxFolder
            //
            this.textBoxFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFolder.Location = new System.Drawing.Point(173, 10);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.ReadOnly = true;
            this.textBoxFolder.Size = new System.Drawing.Size(1010, 23);
            this.textBoxFolder.TabIndex = 1;
            //
            // splitContainerMain
            //
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(3, 51);
            this.splitContainerMain.Name = "splitContainerMain";
            //
            // splitContainerMain.Panel1
            //
            this.splitContainerMain.Panel1.Controls.Add(this.listBoxFiles);
            this.splitContainerMain.Panel1MinSize = 180;
            //
            // splitContainerMain.Panel2
            //
            this.splitContainerMain.Panel2.Controls.Add(this.tableLayoutViewer);
            this.splitContainerMain.Panel2MinSize = 300;
            this.splitContainerMain.Size = new System.Drawing.Size(1194, 670);
            this.splitContainerMain.SplitterDistance = 280;
            this.splitContainerMain.TabIndex = 1;
            //
            // listBoxFiles
            //
            this.listBoxFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.IntegralHeight = false;
            this.listBoxFiles.ItemHeight = 15;
            this.listBoxFiles.Location = new System.Drawing.Point(0, 0);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(280, 670);
            this.listBoxFiles.TabIndex = 0;
            this.listBoxFiles.SelectedIndexChanged += new System.EventHandler(this.ListBoxFiles_SelectedIndexChanged);
            //
            // tableLayoutViewer
            //
            this.tableLayoutViewer.ColumnCount = 1;
            this.tableLayoutViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutViewer.Controls.Add(this.panelZoom, 0, 0);
            this.tableLayoutViewer.Controls.Add(this.pdfViewer, 0, 1);
            this.tableLayoutViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutViewer.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutViewer.Name = "tableLayoutViewer";
            this.tableLayoutViewer.RowCount = 2;
            this.tableLayoutViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutViewer.Size = new System.Drawing.Size(910, 670);
            this.tableLayoutViewer.TabIndex = 0;
            //
            // panelZoom
            //
            this.panelZoom.Controls.Add(this.buttonZoomPage);
            this.panelZoom.Controls.Add(this.buttonZoomHeight);
            this.panelZoom.Controls.Add(this.buttonZoomWidth);
            this.panelZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelZoom.Location = new System.Drawing.Point(3, 3);
            this.panelZoom.Name = "panelZoom";
            this.panelZoom.Size = new System.Drawing.Size(904, 34);
            this.panelZoom.TabIndex = 0;
            //
            // buttonZoomWidth
            //
            this.buttonZoomWidth.Location = new System.Drawing.Point(0, 3);
            this.buttonZoomWidth.Name = "buttonZoomWidth";
            this.buttonZoomWidth.Size = new System.Drawing.Size(110, 28);
            this.buttonZoomWidth.TabIndex = 0;
            this.buttonZoomWidth.Text = "auf Breite";
            this.buttonZoomWidth.UseVisualStyleBackColor = true;
            this.buttonZoomWidth.Click += new System.EventHandler(this.ButtonZoomWidth_Click);
            //
            // buttonZoomHeight
            //
            this.buttonZoomHeight.Location = new System.Drawing.Point(116, 3);
            this.buttonZoomHeight.Name = "buttonZoomHeight";
            this.buttonZoomHeight.Size = new System.Drawing.Size(110, 28);
            this.buttonZoomHeight.TabIndex = 1;
            this.buttonZoomHeight.Text = "auf Höhe";
            this.buttonZoomHeight.UseVisualStyleBackColor = true;
            this.buttonZoomHeight.Click += new System.EventHandler(this.ButtonZoomHeight_Click);
            //
            // buttonZoomPage
            //
            this.buttonZoomPage.Location = new System.Drawing.Point(232, 3);
            this.buttonZoomPage.Name = "buttonZoomPage";
            this.buttonZoomPage.Size = new System.Drawing.Size(110, 28);
            this.buttonZoomPage.TabIndex = 2;
            this.buttonZoomPage.Text = "Ganze Seite";
            this.buttonZoomPage.UseVisualStyleBackColor = true;
            this.buttonZoomPage.Click += new System.EventHandler(this.ButtonZoomPage_Click);
            //
            // pdfViewer
            //
            this.pdfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer.Location = new System.Drawing.Point(3, 43);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.Size = new System.Drawing.Size(904, 624);
            this.pdfViewer.TabIndex = 1;
            //
            // panelRename
            //
            this.panelRename.Controls.Add(this.buttonRename);
            this.panelRename.Controls.Add(this.textBoxNewName);
            this.panelRename.Controls.Add(this.labelFileName);
            this.panelRename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRename.Location = new System.Drawing.Point(3, 727);
            this.panelRename.Name = "panelRename";
            this.panelRename.Size = new System.Drawing.Size(1194, 42);
            this.panelRename.TabIndex = 2;
            //
            // labelFileName
            //
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(7, 13);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(67, 15);
            this.labelFileName.TabIndex = 0;
            this.labelFileName.Text = "Dateiname:";
            //
            // textBoxNewName
            //
            this.textBoxNewName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewName.Location = new System.Drawing.Point(90, 10);
            this.textBoxNewName.Name = "textBoxNewName";
            this.textBoxNewName.Size = new System.Drawing.Size(980, 23);
            this.textBoxNewName.TabIndex = 1;
            //
            // buttonRename
            //
            this.buttonRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRename.Location = new System.Drawing.Point(1076, 7);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(110, 28);
            this.buttonRename.TabIndex = 2;
            this.buttonRename.Text = "Umbenennen";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.ButtonRename_Click);
            //
            // labelStatus
            //
            this.labelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStatus.Location = new System.Drawing.Point(3, 775);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.labelStatus.Size = new System.Drawing.Size(1194, 22);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Bitte ein Verzeichnis wählen.";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // Form1
            //
            this.AcceptButton = this.buttonRename;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.tableLayoutRoot);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF-Umbenennen";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tableLayoutRoot.ResumeLayout(false);
            this.panelFolder.ResumeLayout(false);
            this.panelFolder.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.splitContainerMain).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.tableLayoutViewer.ResumeLayout(false);
            this.panelZoom.ResumeLayout(false);
            this.panelRename.ResumeLayout(false);
            this.panelRename.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutRoot = null!;
        private System.Windows.Forms.Panel panelFolder = null!;
        private System.Windows.Forms.Button buttonSelectFolder = null!;
        private System.Windows.Forms.TextBox textBoxFolder = null!;
        private System.Windows.Forms.SplitContainer splitContainerMain = null!;
        private System.Windows.Forms.ListBox listBoxFiles = null!;
        private System.Windows.Forms.TableLayoutPanel tableLayoutViewer = null!;
        private System.Windows.Forms.Panel panelZoom = null!;
        private System.Windows.Forms.Button buttonZoomWidth = null!;
        private System.Windows.Forms.Button buttonZoomHeight = null!;
        private System.Windows.Forms.Button buttonZoomPage = null!;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer = null!;
        private System.Windows.Forms.Panel panelRename = null!;
        private System.Windows.Forms.Label labelFileName = null!;
        private System.Windows.Forms.TextBox textBoxNewName = null!;
        private System.Windows.Forms.Button buttonRename = null!;
        private System.Windows.Forms.Label labelStatus = null!;
    }
}
