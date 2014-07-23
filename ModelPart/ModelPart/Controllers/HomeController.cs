using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelPart.Models;

namespace ModelPart.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new RegistrationModel();
            
            //Заполняем значения для выпадающего списка. 
            //Text - то что будет видеть пользователь , 
            //Value - то что запишется в поле модели
            model.Cities = new List<SelectListItem>
                               {
                                   new SelectListItem
                                       {
                                           Text = "Kyiv",
                                           Value = "Kyiv"
                                       },
                                       new SelectListItem
                                       {
                                           Text = "Lviv",
                                           Value = "Lviv"
                                       },
                                       new SelectListItem
                                       {
                                           Text = "Donetsk",
                                           Value = "Donetsk"
                                       },
                                       new SelectListItem
                                       {
                                           Text = "Odessa",
                                           Value = "Odessa"
                                       },
                               };
            return View(model);
        }
    }
}
