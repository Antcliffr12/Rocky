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
    public class ApplicationController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ApplicationController(ApplicationDbContext db)
        {
            _db = db;
        }
       
        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Application> appList = _db.Application;
            return View(appList);
        }

        //GET - Create
        public IActionResult Create()
        {
            return View();
        }

        //POST -Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Application appObj)
        {
            if (ModelState.IsValid)
            {
                _db.Application.Add(appObj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appObj);
           
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            //Finding Id
            var app = _db.Application.Find(id);

            //if app is not found
            if(app == null)
            {
                return NotFound();
            }

            //if id and app is found
            return View(app);
        }

        //POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken] //validates token auto 
        public IActionResult Edit(Application app)
        {
            if (ModelState.IsValid)
            {
                _db.Application.Update(app);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(app);
        }

        //Get - Delete
        public IActionResult Delete(int? id)
        {
            //if cant find Id
            if(id == null || id == 0)
            {
                return NotFound();
            }

            //finding Id
            var app = _db.Application.Find(id);

            //if Obj is not found
            if (app == null)
            {
                return NotFound();
            }

            //if id and app is found
            return View(app);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var app = _db.Application.Find(id);
            if (app == null)
            {
                return NotFound();
            }

            _db.Application.Remove(app);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
