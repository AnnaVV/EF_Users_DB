using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFModel.Models;
using ModelPart.Models;

namespace EFModel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var entites = new DataEntities();
            var model = new RegistrationModel();
            model.Cities = ConvertEntities(entites.Cities);

            return View(model);
        }

        private List<SelectListItem> ConvertEntities(DbSet<City> cities)
        {
            var list = new List<SelectListItem>();

            foreach (var city in cities)
            {
                list.Add(new SelectListItem
                             {
                                 Text = city.Name,
                                 Value = city.Name
                             });
            }

            return list;
        }
    }
}
