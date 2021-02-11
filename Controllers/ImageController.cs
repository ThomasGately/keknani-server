using System;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace keknani_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                Console.WriteLine("test");
                List<string> ImgPaths = new List<string>();
                var files = Request.Form.Files;
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                /* if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                } */

                foreach (var file in files)
                {
                    //var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fileExtension = System.IO.Path.GetExtension(ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName).Trim('"');
                    var guid = Guid.NewGuid();
                    var fileName = guid + fileExtension;
                    var fullPath = Path.Combine(pathToSave, fileName);
                    ImgPaths.Add(Path.Combine(folderName, fileName));

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok(new { ImgPaths });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}