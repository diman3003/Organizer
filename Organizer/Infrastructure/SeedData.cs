using System;
using System.Collections.Generic;
using System.Linq;
using Organizer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Organizer.Infrastructure
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app, int entitiesCount)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if(!context.Contacts.Any())
            {
                List<Contact> contacts = new List<Contact>(entitiesCount);

                for(int i = 1; i < entitiesCount+1; i++)
                {
                    contacts.Add(new Contact { FirstName = $"FirstName{i}", LastName = $"LastName{i}", SecondName = $"SecondName{i}", Company = $"Company{i*2}", Job = $"{i}-Job", BirthDate = new DateTime(2000+i, 5, i).Date });
                }

                context.AddRange(contacts);
                context.SaveChanges();
                context.Add(new ContactInfo { Type = "Mail", Value = "diman@mail.ru", ContactID = context.Contacts.First().ID });
                context.Add(new ContactInfo { Type = "Phone", Value = "(3412)22-53-13", ContactID = context.Contacts.Last().ID });
                context.Add(new ContactInfo { Type = "Phone", Value = "89058755575", ContactID = context.Contacts.Last().ID });
                context.SaveChanges();
            }
        }
    }
}
