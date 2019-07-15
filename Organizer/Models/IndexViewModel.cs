using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<ContactInfo> ContactInfos { get; set; }
    }
}
