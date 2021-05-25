using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] UploadFileForm form)
        {
            await using var stream = new MemoryStream();
            await form.File.CopyToAsync(stream);

            return Ok($"File received {form.File.FileName} with length {form.File.Length} and description {form.FileDescription}");
        }
    }
}
