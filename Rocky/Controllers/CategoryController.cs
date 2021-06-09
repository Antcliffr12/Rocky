using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }

        //GET - Create 
        public IActionResult Create()
        {
            return View();
        }

        //POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken] //validates token auto 
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);  
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            //if cant find Id
            if(id == null || id == 0)
            {
                return NotFound();
            }

            //Finding Id 
            var obj = _db.Category.Find(id);

            //if Obj is not found
            if(obj == null)
            {
                return NotFound();
            }

            //if id and obj is found 
            return View(obj);
        }

        //POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken] //validates token auto 
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET - Delete
        public IActionResult Delete(int? id)
        {
            //if cant find Id
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Finding Id 
            var obj = _db.Category.Find(id);

            //if Obj is not found
            if (obj == null)
            {
                return NotFound();
            }

            //if id and obj is found 
            return View(obj);
        }

       //POST - DELETE
       [HttpPost]
       [ValidateAntiForgeryToken]

       public IActionResult DeletePost(int? id)
        {
            var obj = _db.Category.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
