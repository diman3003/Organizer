using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Organizer.Models;

namespace Organizer.Controllers
{
    public class ContactInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        string[] infoTypes = new string[4]{ "Mail", "Phone", "Skype", "Other" };

        public ContactInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContactInfoes
        public async Task<IActionResult> Index(int? id)
        {
            var applicationDbContext = _context.ContactInfos.Where(c => c.ContactID == id).Include(c => c.Contact);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ContactInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfo = await _context.ContactInfos
                .Include(c => c.Contact)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            return View(contactInfo);
        }

        // GET: ContactInfoes/Create
        public IActionResult Create(int? id)
        {
            ViewBag.CID = id;
            ViewData["Type"] = new SelectList(infoTypes);
            return View();
        }

        // POST: ContactInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Type,Value,ContactID")] ContactInfo contactInfo)
        {

            ViewData["Type"] = new SelectList(infoTypes);
            if (ModelState.IsValid)
            {
                _context.Add(contactInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Contact");
            }
            
            return View(contactInfo);
        }

        // GET: ContactInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfo = await _context.ContactInfos.FindAsync(id);
            if (contactInfo == null)
            {
                return NotFound();
            }
            ViewData["Type"] = new SelectList(_context.ContactInfos.Select(c => c.Type).Distinct());
            ViewData["ContactID"] = new SelectList(_context.Contacts, "ID", "FirstName", contactInfo.ContactID);
            return View(contactInfo);
        }

        // POST: ContactInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Type,Value,ContactID")] ContactInfo contactInfo)
        {
            if (id != contactInfo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactInfoExists(contactInfo.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Contact");
            }

            ViewData["Type"] = new SelectList(infoTypes);
            ViewData["ContactID"] = new SelectList(_context.Contacts, "ID", "FirstName", contactInfo.ContactID);
            return View(contactInfo);
        }

        // GET: ContactInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfo = await _context.ContactInfos
                .Include(c => c.Contact)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            return View(contactInfo);
        }

        // POST: ContactInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactInfo = await _context.ContactInfos.FindAsync(id);
            _context.ContactInfos.Remove(contactInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Contact");
        }

        private bool ContactInfoExists(int id)
        {
            return _context.ContactInfos.Any(e => e.ID == id);
        }
    }
}
