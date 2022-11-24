using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Data.Entities.Identity;

namespace OnlineShop.Service.Interfaces
{
    public interface IContactService
    {
        Task <Contact> GetContact();
        Task<IEnumerable<Contact>> GetContactById(Guid id);
        Task<IEnumerable<Contact>> AddContact(Contact contact);
        Task<IEnumerable<Contact>> EditContact(Contact contact);
        Task<Contact> DeleteContact(Guid id);
    }
}
