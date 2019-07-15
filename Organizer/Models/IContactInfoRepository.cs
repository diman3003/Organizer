using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Models
{
    public interface IContactInfoRepository
    {
        IQueryable<ContactInfo> ContactInfos { get; set; }
    }
}
