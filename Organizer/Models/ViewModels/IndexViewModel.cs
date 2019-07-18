using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Organizer.Models.ViewModels;

namespace Organizer.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<ContactInfo> ContactInfos { get; set; }
        public PagingInfo PageInfo { get; set; }
    }
}
