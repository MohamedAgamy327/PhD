using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.DTO
{
    public class FileDTO
    {
        [FromForm(Name = "file")]
        public IFormFile File { get; set; }
    }
}
