using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLOG.Yeni.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;

namespace BLOG.Yeni.Controllers
{
    public class AdminController : Controller
    {
        private readonly ErrorService _errorService;
        private readonly CategoryService _categoryService;
        private readonly UserService _userService;
        //www.summeye.com/admin/index
        public AdminController(UserService userService,ErrorService errorService, CategoryService categoryService)
        {
            _errorService = errorService;
            _categoryService = categoryService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username")==null )
            {
               return RedirectToAction("UserGiris");
            }
            else
            {
                return View();
            }
           
        }
        public IActionResult CategoryList()
        {
            return View(_categoryService.GetAll());

        }
        public IActionResult CategoryAdd()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category deneme)
        {

            _categoryService.Create(deneme);
            return RedirectToAction("listeleverileri","Home");
        }
        public IActionResult ErrorList()
        {
            return View(_errorService.GetAll());
        }
        public IActionResult ErrorAdd()
        {



            var adata = _categoryService.GetAll();

            List<SelectListItem> degerler = (from i in adata
                                             select new SelectListItem
                                             {
                                                 Text = i.Category_Name,
                                                 Value = i.Category_id.ToString()
                                             }).ToList();


            ViewBag.verilerim = degerler;

            ViewBag.veri = _errorService.GetAll();


            return View();
        }
        [HttpPost]
        public IActionResult ErrorAdd(Errors deneme)
        {
           // ObjectId verim = ObjectId.Parse(deneme._idString);
           // var categoryid = _categoryService.Get(deneme.Category_id);
             //deneme.Category_id = categoryid.Category_id;
            _errorService.Create(deneme);
            return RedirectToAction("listeleverileri","Home");
        }
        //Kategori Duzenle
        public IActionResult Edit(int id)
        {
            
            return View(_categoryService.Get(id));
        }
        //Kategori Duzenle Post Devami
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            return RedirectToAction("CategoryList");
            
        }
        //Error Duzenle
        public IActionResult Duzenle(string objectId)
        {
            var bilgi = ObjectId.Parse(objectId);
            TempData["duzenle"] = objectId;
            var veri = _errorService.Get(bilgi);
            
            return View(veri);
        }
        //Error Duzenle Post devami 
        [HttpPost]
        public IActionResult Duzenle(Errors errors)
        {
            var veri = TempData["duzenle"].ToString();
            var bilgi = ObjectId.Parse(veri);
            Errors guncelle = new Errors();
            guncelle._id = bilgi;
            guncelle.Category_id = errors.Category_id;
            guncelle.Error_Name = errors.Error_Name;
            guncelle.Solution = errors.Solution;
            _errorService.Update(bilgi,guncelle);
            return RedirectToAction("ErrorList");
        }
        //KategoriSilme
        public IActionResult Sil(int id)
        {
            return View(_categoryService.Get(id));
        }
        //KategoriSilme Post son kısmı
        [HttpPost]
        public IActionResult Sil(Category deneme)
        {
           // var categori=_categoryService.Get(id);
            _categoryService.Remove(deneme);
            return  RedirectToAction("CategoryList");
        }
        //Error Silme islemi
        public IActionResult Silerrors(string objectId)
        {
            var bilgi = ObjectId.Parse(objectId);
           var verim= _errorService.Get(bilgi);
            _errorService.Remove(verim);
            return RedirectToAction("ErrorList");
        }
        public IActionResult UserGiris()
        {
            return View();
        }
        public IActionResult Girisyap(kullaniciislem users)
        {
            var user = _userService.GetAll().Count();
            var email=_userService.GetirEmail(users.kullanici);
            var username=_userService.GetirUsername(users.kullanici);
            if (email==null && username==null)
            {
                return RedirectToAction("UserGiris");
            }
            if (email != null && username == null)
            {
                HttpContext.Session.SetString("username", email.User_Name);
                HttpContext.Session.SetString("email", email.User_email);
                return RedirectToAction("Index");
            }
            if (email==null && username!=null)
            {
                HttpContext.Session.SetString("username", username.User_Name);
                HttpContext.Session.SetString("email", username.User_email);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }



    }
}
