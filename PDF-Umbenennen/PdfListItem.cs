namespace PDF_Umbenennen
{
    internal sealed class PdfListItem
    {
        public PdfListItem(string fullPath)
        {
            FullPath = fullPath;
            FileName = System.IO.Path.GetFileName(fullPath);
        }

        public string FullPath { get; }

        public string FileName { get; }

        public override string ToString()
        {
            return FileName;
        }
    }
}
