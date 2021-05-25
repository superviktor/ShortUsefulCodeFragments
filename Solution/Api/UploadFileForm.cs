using Microsoft.AspNetCore.Http;

namespace Api
{
    public class UploadFileForm
    {
        public IFormFile File { get; set; }
        public string FileDescription { get; set; }
    }
}
