using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Compsci335_A1.Data;
using Compsci335_A1.Models;
using System.IO;

namespace Compsci335_A1.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IWebApiRepo _repository;

        public ProductController(IWebApiRepo repository)
        {
            _repository = repository;
        }

        // GET /api/GetItems (all of the items)
        [HttpGet("GetItems")]
        public ActionResult<IEnumerable<Product>> GetAllItem()
        {
            IEnumerable<Product> products = _repository.getAllItems();
            return Ok(products);
        }

        // Get /api/GetItems/b (all items containing b - case insensitive)
        [HttpGet("GetItems/{name}")]
        public ActionResult<IEnumerable<Product>> GetAllItem(string name)
        {
            IEnumerable<Product> products = _repository.getItemsWithPartial(name);
            return Ok(products);
        }

        // GET /api/GetStaffPhoto/{id}
        [HttpGet("GetItemPhoto/{id}")]

        public ActionResult getItemPhoto(string id)
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "ItemsImages");
            string fileName1 = Path.Combine(imgDir, id + ".jpg");
            string fileName2 = Path.Combine(imgDir, id + ".png");
            string fileName3 = Path.Combine(imgDir, id + ".png");

            string defaultFile = Path.Combine(imgDir, "default.png");

            if (System.IO.File.Exists(fileName1))
            {
                return PhysicalFile(fileName1, "image/jpeg");
            }
            else if (System.IO.File.Exists(fileName2))
            {
                return PhysicalFile(fileName2, "image/png");
            }
            else if (System.IO.File.Exists(fileName3))
            {
                return PhysicalFile(fileName3, "image/gif");
            }

            return PhysicalFile(defaultFile, "image/png");
        }
    }
}
