using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Compsci335_A1.Data;
using Compsci335_A1.Models;
using Compsci335_A1.Dtos;
using Compsci335_A1.Helper;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Compsci335_A1.Controllers
{
    [Route("api")]
    [ApiController]
    public class StaffController : Controller
    {
        private readonly IWebApiRepo _repository;

        public StaffController(IWebApiRepo repository)
        {
            _repository = repository;
        }

        // GET /api/GetAllStaff
        [HttpGet("GetAllStaff")]
        public ActionResult<IEnumerable<Staff>> GetAllStaff()
        {
            IEnumerable<Staff> staffs = _repository.getAllStaffs();
            return Ok(staffs);
        }

        // GET /api/GetStaffPhoto/{id}
        [HttpGet("GetStaffPhoto/{id}")]

        public ActionResult getStaffPhoto(string id)
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "StaffPhotos");
            string fileName1 = Path.Combine(imgDir, id + ".jpg");
            string fileName2 = Path.Combine(imgDir, id + ".png");
            string fileName3 = Path.Combine(imgDir, id + ".gif");
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

        [HttpGet("GetCard/{id}")]
        public ActionResult GetCard(int id)
        {
            Staff staff = _repository.getStaff(id);
            string path = Directory.GetCurrentDirectory();
            string fileName1 = Path.Combine(path, "StaffPhotos/" + id + ".jpg");
            string fileName2 = Path.Combine(path, "StaffPhotos/" + id + ".png");
            string fileName3 = Path.Combine(path, "StaffPhotos/" + id + ".gif");
            string defaultFileName = Path.Combine(path, "StaffPhotos/logo.png");

            string photoString, photoType;
            string logoString, logoType;
            ImageFormat imageFormat;
            StaffCardOut cardOut = new StaffCardOut();
            if (System.IO.File.Exists(fileName1))
            {
                Image image = Image.FromFile(fileName1);
                imageFormat = image.RawFormat;
                image = ImageHelper.Resize(image, new Size(200, 200), out photoType);
                photoString = ImageHelper.ImageToString(image, imageFormat);
            }
            else if (System.IO.File.Exists(fileName2))
            {
                Image image = Image.FromFile(fileName2);
                imageFormat = image.RawFormat;
                image = ImageHelper.Resize(image, new Size(200, 200), out photoType);
                photoString = ImageHelper.ImageToString(image, imageFormat);
            }
            else if (System.IO.File.Exists(fileName3))
            {
                Image image = Image.FromFile(fileName3);
                imageFormat = image.RawFormat;
                image = ImageHelper.Resize(image, new Size(200, 200), out photoType);
                photoString = ImageHelper.ImageToString(image, imageFormat);
            }
            else
            {
                
                Image image = Image.FromFile(defaultFileName);
                imageFormat = image.RawFormat;
                image = ImageHelper.Resize(image, new Size(100, 100), out logoType);
                logoString = ImageHelper.ImageToString(image, imageFormat);

                cardOut.Name = ";;;;";
                cardOut.Logo = logoString;
                cardOut.LogoType = logoType;
                cardOut.Uid = -1;
                
                Response.Headers.Add("Content-Type", "text/vcard");
                return Ok(cardOut);
            }
            
            cardOut.Name = staff.FirstName + ";" + staff.LastName + ";;" + staff.Title + ";";
            cardOut.FullName = staff.Title + " " + staff.LastName + " " + staff.FirstName;
            cardOut.Email = staff.Email;
            cardOut.Tel = staff.Tel;
            cardOut.Url = staff.Url;
            cardOut.Company = "Southern Hemisphere Institute of Technology";
            cardOut.Uid = staff.Id;
            cardOut.Photo = photoString;
            cardOut.PhotoType = photoType;

            Image logo = Image.FromFile(defaultFileName);
            ImageFormat logoFormat = logo.RawFormat;
            logo = ImageHelper.Resize(logo, new Size(100, 100), out logoType);
            logoString = ImageHelper.ImageToString(logo, logoFormat);

            cardOut.Logo = logoString;
            cardOut.LogoType = logoType;

            cardOut.Categories = Helper.ResearchFilter.Filter(staff.Research);
            Response.Headers.Add("Content-Type", "text/vcard");

            return Ok(cardOut);
        }
    }
}
