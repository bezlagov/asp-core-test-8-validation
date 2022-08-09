using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using Task8.Models;

namespace Task8.Controllers
{
    public class HomeController : Controller
    {
        private List<string> products = new List<string> { "Basics", "JavaScript", "C#", "Java", "Python" };
        public IActionResult Index()
        {


            List<SelectListItem> data = new List<SelectListItem>();

            for (int i = 0; i < products.Count; i++)
            {
                data.Add(new SelectListItem(products[i], products[i]));
            }
            ViewBag.Options = data;
            return View();
        }

        public IActionResult Schedule(Consultation consultation)
        {
            ViewBag.Message = "Appointment scheduled";
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Error";
            }
            if (consultation == null)
            {
                ViewBag.Message = "Model is null";
            }
            else
            {
                if (String.IsNullOrEmpty(consultation.ClientName))
                {
                    ViewBag.Message = "You need to enter user name";
                }
                if (String.IsNullOrEmpty(consultation.ClientSurname))
                {
                    ViewBag.Message = "You need to enter user surname";
                }

                if (consultation.Date < DateTime.Now)
                {
                    ViewBag.Message = "Appointment can't be in the past";
                }
                else
                {
                    if (consultation.Date.DayOfWeek == DayOfWeek.Saturday || consultation.Date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        ViewBag.Message = "It should be a working day";
                    }

                    if (consultation.ConsultType == "Basics")
                    { 
                        ViewBag.Message = "Basics can't be on Monday";
                    }
                }
            }
            return View();

        }
    }
}
