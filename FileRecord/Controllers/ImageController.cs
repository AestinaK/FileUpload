using FileRecord.Extension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace FileRecord.Controllers
{
    [Area("Application")]
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public Task<IActionResult> Index(string path)
        {
            try
            {
               if(string.IsNullOrWhiteSpace(path))
                    throw new ArgumentNullException(nameof(path));
                path = path.Replace('/', '\\');
                var rootPath = _webHostEnvironment.ContentRootPath + path;
                var fileDownloadName = path.Split(new[] { '/', '\\' }).Last();
                var provider = new FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(rootPath, out var contentType))
                {
                    contentType = "application/octet-stream";
                }
                Response.Headers.Add("content-disposition", "inline");
                return Task.FromResult<IActionResult>(PhysicalFile(rootPath, contentType, fileDownloadName, enableRangeProcessing: true));
            }
            catch (Exception e)
            {
                return Task.FromResult(this.SendError(e.Message));
            }
        }
        }
}
