using Intro_To_ASP.NET.Models;
using Intro_To_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intro_To_ASP.NET.Controllers
{
    public class HomeController: Controller
    {
        // /Home/Index
        //public string Index()
        //{
        //    return "INDEX";
        //}

        public IActionResult Index()
        {
            string number = "+99659703235";
            ViewBag.Number = number;
            ViewBag.Name = "Vladimir";

            ViewData["Salary"] = "15K";

            ViewBag.Lists = new List<string>() { "One", "Two", "Three" };
            
            return View();
        }
        public IActionResult Contact()
        {
           
            Person person = new Person();
            //Car car = new Car();
            //car.@class = 10;
            //car.@namespace = 1;
            //car.Marka = "Lada";

           

            person.Name = "Vladimir";
            person.Surname = "Vinnik";
            person.Age = 41;
            //ViewBag.Person = person;
            TempData["message"] = "Hello!!!";

            ContactVitewModel contactVitewModel = new ContactVitewModel();
            contactVitewModel.Person = person;
            contactVitewModel.Car = new Car() { @class = 1, @void = 1, @int = 1, Marka = "Lada" };
            contactVitewModel.Dog = new Dog() { Name = "Sharik" };

            return View(contactVitewModel);
        }

        public IActionResult Data(string search /*int id*/)
        {
            // ViewBag.Id = id;
            ViewBag.Search = search;
            return View();
        }
    }
}
