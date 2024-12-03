using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebGUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Department> d = new List<Department>();
            d.Add(new Department("1"));
            d.Add(new Department("2"));
            d.Add(new Department("3"));
            d.Add(new Department("4"));
            ViewBag.Departments = new SelectList(d, "Name");
            return View(d);
        }
    }
}