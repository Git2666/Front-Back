using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Interface;
using System.Net;
using System.Net.Http.Headers;
using System.Web;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class BookController : ControllerBase
    {
        public IBookService _bookService { get; set; }

        public BookController(IBookService service)
        {
            _bookService = service;
        }

        [HttpGet]
        public List<string> Glance()
        { 
            return _bookService.FindBooks();
        }

        [HttpGet]
        public async Task<IActionResult> DownloadBook(string filename)
        {
            string filePath = Path.Combine(_bookService.GetPath(), filename);
            

            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true);


            //var encodedFilename = Uri.EscapeDataString(filename);
            return File(stream, "application/octet-stream", filename);
            
        }
    }
}
