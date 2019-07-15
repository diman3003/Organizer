using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Models
{
    public class ContactInfoRepository
    {
        private ApplicationDbContext context;

        public ContactInfoRepository(ApplicationDbContext ctx) => context = ctx;

        public IQueryable<ContactInfo> ContactInfos => context.ContactInfos;
    }
}
