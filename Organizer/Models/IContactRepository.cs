using System.Linq;

namespace Organizer.Models
{
    public interface IContactRepository
    {
        IQueryable<Contact> Contacts { get; }
    }
}
