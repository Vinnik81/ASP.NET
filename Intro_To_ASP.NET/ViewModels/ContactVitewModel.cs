using Intro_To_ASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intro_To_ASP.NET.ViewModels
{
    public class ContactVitewModel
    {
        public Car Car { get; set; }
        public Person Person { get; set; }
        public Dog Dog { get; set; }
    }
}
