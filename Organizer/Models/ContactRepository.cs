using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizer.Models
{
    public class ContactRepository : IContactRepository
    {
        private ApplicationDbContext context;

        public ContactRepository(ApplicationDbContext ctx) => this.context = ctx;

        public IQueryable<Contact> Contacts => this.context.Contacts;
    }
}
