using Microsoft.AspNetCore.Http;

namespace Seminars.Models.Upload
{
    public class FileInputModel
    {
        public IFormFile FileToUpload { get; set; }
    }
}
