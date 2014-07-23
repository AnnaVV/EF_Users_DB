using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
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

        //Этот аттрибут позволяет делать вызов этого екшона только при POST запросе
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            var entites = new DataEntities();
            var selectedCity = entites.Cities.ToList().First(x => x.Id == int.Parse(form["City"]));

            var info = new RegistrationInfo
                           {
                               City = selectedCity,
                               Email = form["Email"],
                               Name = form["Name"],
                               Password = form["Password"]
                           };

            entites.RegistrationInfoes.Add(info);
            entites.SaveChanges();

            return RedirectToAction("Index");
        }

        private List<SelectListItem> ConvertEntities(DbSet<City> cities)
        {
            var list = new List<SelectListItem>();

            foreach (var city in cities)
            {
                list.Add(new SelectListItem
                {
                    Text = city.Name,
                    Value = city.Id.ToString(CultureInfo.InvariantCulture)
                });
            }

            return list;
        }

        public ActionResult ShowDB()
        {
            var entities = new DataEntities();

            var model = entities.RegistrationInfoes.ToList(); //TODO: make join with "Cities" table to get City name by CityID
            return View(model);
        }

        public ActionResult DeleteUser(int id)
        {
            var entities = new DataEntities();
            RegistrationInfo user = entities.RegistrationInfoes.Find(id);
            entities.RegistrationInfoes.Remove(user);
            entities.SaveChanges();
            return RedirectToAction("ShowDB");
        }
    }
}
