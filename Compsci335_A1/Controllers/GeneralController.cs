using Compsci335_A1.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Compsci335_A1.Controllers
{
    [Route("api")]
    [ApiController]
    public class GeneralController : Controller
    {
        private readonly IWebApiRepo _repository;

        public GeneralController(IWebApiRepo repository)
        {
            _repository = repository;
        }

        // GET /api/GetVersion
        [HttpGet("GetVersion")]
        public ActionResult GetVersion()
        {
            return Content(_repository.getVersion());
        }

        // Get /api/GetLogo
        [HttpGet("GetLogo")]
        public ActionResult getLogo()
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "StaffPhotos");
            string fileName = Path.Combine(imgDir, "logo.png");

            if(System.IO.File.Exists(fileName))
            {
                return PhysicalFile(fileName, "image/png");
            }

            return NotFound();
        }
    }
}
