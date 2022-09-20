using CRUD.Data;
using CRUD.Models;
using CRUD.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        private readonly ApplicationContext context;
        private readonly IHostingEnvironment environment;

        public UploadController(ApplicationContext context, IHostingEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        [HttpGet]
        public IActionResult UploadImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadImage(ImageCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var path = environment.WebRootPath;
                var filePath = "Content/Image/" + model.ImagePath.FileName;
                var fullPath = Path.Combine(path, filePath);
                UploadFile(model.ImagePath, fullPath);
                var data = new Image()
                {
                    Name = model.Name,
                    ImagePath = filePath
                };
                context.Add(data);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        [AllowAnonymous]
        public void UploadFile(IFormFile file, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
        }
        public IActionResult Index()
        {
            var data = context.Images.ToList();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var data = context.Images.SingleOrDefault(e => e.Id == id);
            context.Images.Remove(data);
            context.SaveChanges();
            TempData["error"] = "Record Deleted";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var data = context.Images.SingleOrDefault(e => e.Id == id);
            var result = new Image()
            {
                Name = data.Name,
                ImagePath = data.ImagePath
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Image model)
        {
            var data = new Image()
            {
                Id = model.Id,
                Name=model.Name,
                ImagePath=model.ImagePath
            };
            context.Images.Update(data);
            context.SaveChanges();
            TempData["error"] = "Record Updated";
            return RedirectToAction("Index");

        }
        
    }
}
