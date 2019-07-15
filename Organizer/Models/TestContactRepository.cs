using System;
using System.Collections.Generic;
using System.Linq;

namespace Organizer.Models
{
    public class TestContactRepository : IContactRepository
    {
        public IQueryable<Contact> Contacts => new List<Contact>
        {
            new Contact{FirstName = "f1" ,LastName = "l1", SecondName = "s1", BirthDate = new DateTime(2000, 1, 1)},
            new Contact{FirstName = "f2" ,LastName = "l2", SecondName = "s2", BirthDate = new DateTime(2000, 2, 2)},
            new Contact{FirstName = "f3" ,LastName = "l3", SecondName = "s3", BirthDate = new DateTime(2000, 3, 3)}
        }.AsQueryable<Contact>();
    }
}
