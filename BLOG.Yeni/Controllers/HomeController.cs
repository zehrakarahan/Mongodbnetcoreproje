using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BLOG.Yeni.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using MongoDB.Bson;
using MongoDB.Driver.Core.WireProtocol.Messages.Encoders.BinaryEncoders;

namespace BLOG.Yeni.Controllers
{
    public class HomeController : Controller
    {
        private readonly ErrorService _errorService;
        private readonly CategoryService _categoryService;

        public HomeController(ErrorService errorService, CategoryService categoryService)
        {
            _errorService = errorService;
            _categoryService = categoryService;
        }
        public IActionResult listele()
        {

            return View(_errorService.GetAll());
        }
        public IActionResult ErrorAdd()
        {
          
         
          
            var adata = _categoryService.GetAll();
            
            List<SelectListItem> degerler = (from i in adata
                                             select new SelectListItem
                                             {
                                                 Text=i.Category_Name,
                                                 Value=i._id.ToString()
                                             }).ToList();
            
            
            ViewBag.verilerim = degerler;
           
            ViewBag.veri = _errorService.GetAll();

        
            return View();
        }
        [HttpPost]
        public IActionResult ErrorAdd(Errors deneme)
        {
           // ObjectId verim = ObjectId.Parse(deneme._idString);
            var categoryid = _categoryService.Get(deneme.Category_id);
            deneme.Category_id = categoryid.Category_id;
            _errorService.Create(deneme);
            return RedirectToAction("listeleverileri");
        }
       
        public IActionResult CategoryAdd()
        {
       
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category deneme)
        {

            _categoryService.Create(deneme);
            return RedirectToAction("listeleverileri") ;
        }
        public IActionResult Hata(int id)
        {
         
            ViewBag.Veriler = _errorService.GetList(id);
            return View(_categoryService.GetAll());
        }
        public IActionResult Hakkinda()
        {
            return View(_categoryService.GetAll());
        }
        public IActionResult Iletisim()
        {
            return View(_categoryService.GetAll());
        }
        public IActionResult listeleverileri()
        {

            return View(_categoryService.GetAll());

        }

      

        //public ActionResult Create()
        //{
        //    ViewBag.Blog = new SelectList(ViewBag.Blog.Category.ToList(), "Category_id", "Category_Name");
        //    return View();
        //}
        //[Obsolete]
        //void VeriListele()
        //{
        //    string mongoConnection = _configuration.GetConnectionString("Blog");
        //    MongoClient client = new MongoClient(mongoConnection);

        //    MongoServer server = client.GetServer();

        //    MongoDatabase db = server.GetDatabase("Blog");

        //    var Errors = db.GetCollection<Error>("Errors").FindAll();
        //    var coll = db.GetCollection<Error>("Errors").AsQueryable<Error>();

        //    foreach (var veri in coll)
        //    {
        //        Debug.WriteLine(veri.Error_name);
        //    }
        //}

        //    public IActionResult Privacy()
        //    {
        //        string mongoConnection = _configuration.GetConnectionString("Blog");
        //        MongoClient client = new MongoClient(mongoConnection);

        //        MongoServer server = client.GetServer();

        //        MongoDatabase db = server.GetDatabase("Blog");

        //        var Errors = db.GetCollection<Error>("Errors").FindAll();
        //        var coll = db.GetCollection<Error>("Errors").AsQueryable<Error>();


        //        return View(coll);
        //    }



        //}
        public class Error
        {
            public int Error_id { get; set; }
            public string Error_name { get; set; }
            public int Category_id { get; set; }
            public string Solution { get; set; }

        }
    }
}
