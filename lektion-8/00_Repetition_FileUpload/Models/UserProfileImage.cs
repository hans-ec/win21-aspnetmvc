namespace _00_Repetition_FileUpload.Models
{
    public class UserProfileImage
    {
        public string FileName { get; set; }
        public string FriendlyFileName => FileName.Split("_")[1];

    }
}
