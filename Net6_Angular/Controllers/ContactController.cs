using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net6_Angular.Data;
using Net6_Angular.Models;
using OnlineShop.Service.Interfaces;

namespace Net6_Angular.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ContactController : Controller
    {
        private readonly DataBaseContext dbContext;
        public ContactController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbContext.Contacts.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContact([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if(contact == null)
            {
                return NotFound();
            }    
            return Ok(contact);
        }
        [HttpPost]
        public async Task<IActionResult> AddContacts(AddContactRequest addContactRequest)
        {
            var contacts = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = addContactRequest.Address,
                Email = addContactRequest.Email,
                FullName = addContactRequest.FullName,
                Phone = addContactRequest.Phone
            };
            await dbContext.Contacts.AddAsync(contacts);
            await dbContext.SaveChangesAsync();
            return Ok(contacts);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContacts([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
        {
           var contact = await dbContext.Contacts.FindAsync(id);
           if (contact != null)
            {
                contact.FullName = updateContactRequest.FullName;
                contact.Email = updateContactRequest.Email;
                contact.Phone = updateContactRequest.Phone;
                contact.Address = updateContactRequest.Address;

                await dbContext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContacts([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact != null)
            {
                dbContext.Remove(contact);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
    }
}
