using GradeSystem.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GradeSystem.Controllers
{
    public class RoleController : Controller
    {

        private SystemContext db = new SystemContext();

        // GET: Role
        /// <summary>  
        /// Get All Roles  
        /// </summary>  
        /// <returns></returns>  
        public ActionResult Index()
        {
            var Roles = db.Roles.ToList();
            return View(Roles);
        }

        /// <summary>  
        /// Create  a New role  
        /// </summary>  
        /// <returns></returns>  
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        /// <summary>  
        /// Create a New Role  
        /// </summary>  
        /// <param name="Role"></param>  
        /// <returns></returns>  
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            //db.Roles.Add(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
} 
