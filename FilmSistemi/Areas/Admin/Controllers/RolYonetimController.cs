using FilmSistemi.Areas.Admin.Models;
using FilmSistemi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmSistemi.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class RolYonetimController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: AdminPanel/RolYonetim
        public ActionResult Index()
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var model = roleManager.Roles.ToList();

            return View(model);
        }

        public ActionResult RolEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RolEkle(RolEkleModel rol)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (roleManager.RoleExists(rol.RolAd) == false)
            {
                roleManager.Create(new IdentityRole(rol.RolAd));
            }

            return RedirectToAction("Index");
        }

        public ActionResult RolKullaniciEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RolKullaniciEkle(RolKullaniciEkleModel model)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var kullanici = userManager.FindByName(model.KullaniciAd);

            if (!userManager.IsInRole(kullanici.Id, model.RolAd))
            {
                userManager.AddToRole(kullanici.Id, model.RolAd);
            }


            return RedirectToAction("Index");
        }
    }
}