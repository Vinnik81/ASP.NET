using DinkToPdf;
using DinkToPdf.Contracts;
using HomeWork1_CV.Models;
using HomeWork1_CV.Utility;
using HomeWork1_CV.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace HomeWork1_CV.Controllers
{
    [Route("api/pdfcreator")]
    [ApiController]
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            Person person = new Person();
            person.Name = "Владимир";
            person.Surname = "Винник";
            person.Age = 41;
            person.DateOfBith = new DateTime(1981, 12, 15);
            person.BirthPlace = "Россия, г. Омск";
            CVViewModels cVViewModels = new CVViewModels();
            cVViewModels.Person = person;
            return View(cVViewModels);
        }

        public IActionResult Contact()
        {
            Contact contact = new Contact();
            contact.Location = "Россия, г.Омск, Олимпийская 12";
            contact.Phone = "+7-965-325-45-21";
            contact.Email = "358979037vvv@gmail.com";
            CVViewModels cVViewModels = new CVViewModels();
            cVViewModels.Person = new Person();
            cVViewModels.Person.Name = "Владимир";
            cVViewModels.Person.Surname = "Винник";
            cVViewModels.Contact = contact;
            return View(cVViewModels);
        }

        public IActionResult Skill()
        {
            Skills skills = new Skills();
            CVViewModels cVViewModels = new CVViewModels();
            skills.Skill = new List<Skill>();
            skills.Skill.Add(new Skill 
            {
                DateSkill = "1989 - 1997",
                Scool = "Омская средняя школа №87",
                Qualification = "Выпускник"
        });
            skills.Skill.Add(new Skill
            {
                DateSkill = "1997 - 2001",
                Scool = "Омский техникум водного транспорта",
                Qualification = "Техник-электромеханник по Э.О. и Автоматике"
            });
            skills.Skill.Add(new Skill
            {
                DateSkill = "2001 - 2005",
                Scool = "Омский Государственный Течнический Университет",
                Qualification = "Инженер по специальности Радиотехника"
            });
            skills.Skill.Add(new Skill
            {
                DateSkill = "2021 - 2023",
                Scool = "АНО ДПО Академия Шаг",
                Qualification = "Студент"
            });
            
            cVViewModels.Person = new Person();
            cVViewModels.Person.Name = "Владимир";
            cVViewModels.Person.Surname = "Винник";
            cVViewModels.Skills = skills;
            return View(cVViewModels);
        }

        public IActionResult Job()
        {
            Jobs jobs = new Jobs();
            jobs.Job = new List<Job>();
            jobs.Job.Add(new Job
            {
                DateOfJob = "2005 - 2006",
                Organisation = "АО \"ПО Иртыш\"",
                Position = "Инженер-конструктор. Разработка РЭА и П"
            });
            jobs.Job.Add(new Job
            {
                DateOfJob = "2006 - 2010",
                Organisation = "АО \"ПО РЕЛЕРО\"",
                Position = "Инженер-конструктор. Разработка РЭА и П"
            });
            jobs.Job.Add(new Job
            {
                DateOfJob = "2010 - 2013",
                Organisation = "ООО \"НПЦ Динамика\"",
                Position = "Инженер-электроник. Разработка диагностических контроллеров и входной контроль сетевой и вычислительной техники"
            });
            jobs.Job.Add(new Job
            {
                DateOfJob = "2013 - 2015",
                Organisation = "АО \"Автоматика сервис\"",
                Position = "Инженер-электроник. Ремонт, модернизация и пусконаладка АСУТП"
            });
            jobs.Job.Add(new Job
            {
                DateOfJob = "2015 - ...",
                Organisation = "АО \"НТК Криогенная Техника\"",
                Position = "Инженер-электроник. Ремонт, модернизация и пусконаладка АСУТП"
            });

            CVViewModels cVViewModels = new CVViewModels();
            cVViewModels.Person = new Person();
            cVViewModels.Person.Name = "Владимир";
            cVViewModels.Person.Surname = "Винник";
            cVViewModels.Jobs = jobs;
            return View(cVViewModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private IConverter _converter;

        public HomeController(IConverter converter)
        {
            _converter = converter;
        }

        [HttpGet]
        public IActionResult CreatePDF()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = @"G:\project\ASP.NET Core\HomeWork1_CV"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(),
                WebSettings = {DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "site.css")},
                HeaderSettings = {FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

           var file = _converter.Convert(pdf);

            return File(file ,"application/pdf");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
