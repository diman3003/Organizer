using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Models
{
    public class Contact
    {
        int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }

    }
}
