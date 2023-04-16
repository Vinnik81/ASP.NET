using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork1_CV.Models
{
    public class Contact
    {
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Person Person { get; set; }
    }
}
