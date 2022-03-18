namespace _01_FileUploading.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FriendlyFileName { get; set; }
        public IFormFile File { get; set; }
    }
}
