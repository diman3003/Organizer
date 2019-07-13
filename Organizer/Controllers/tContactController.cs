using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Organizer.Models;

namespace Organizer.Controllers
{
    public class ContactController1 : Controller
    {
        private IContactRepository repository;

        public ContactController1(IContactRepository repo) => this.repository = repo;

        public ViewResult Index() => View(this.repository.Contacts);
    }
}