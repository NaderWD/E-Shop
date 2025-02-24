namespace E_Shop.Application.Tools
{
    public static class FileExtensions
    {
        public static bool IsImageOrPdf(string fileName)
        {
            string[] ex = { ".jpg", ".png", ".pdf" };
            string fileEX = Path.GetExtension(fileName);
            return ex.Any(e => e == fileEX);
        }

        public static bool IsImage(string fileName)
        {
            string[] ex = { ".jpg", ".png", "jfif" };
            string fileEX = Path.GetExtension(fileName);
            return ex.Any(e => e == fileEX);
        }
    }
}
