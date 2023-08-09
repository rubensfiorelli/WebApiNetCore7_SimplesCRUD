using Microsoft.AspNetCore.Mvc;
using Store.Data.DatabaseContext;
using Store.Domain.Dtos;
using Store.Domain.Entities;

namespace Store.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly StoreDbContext _Context;

        public ContactsController(StoreDbContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var contacts = _Context.Contacts.ToList();

            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var contact = _Context.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact is null)
                return NotFound();


            return Ok(contact);
        }

        [HttpPost]
        public IActionResult Create(ContactDto contactDto)
        {

            Contact contact = new Contact()
            {
                Id = contactDto.Id,
                FirstName = contactDto.FirstName,
                LastName = contactDto.LastName,
                Email = contactDto.Email,
                Message = contactDto.Message,
                MobilePhone = contactDto.MobilePhone ?? string.Empty,
                Subject = contactDto.Subject,
                CreateAt = contactDto.CreateAt,
                UpdateAt = contactDto.UpdateAt

            };

            _Context.Add(contact);
            _Context.SaveChanges();

            return Ok(contact);

        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, ContactDto contactDto)
        {
            var contact = _Context.Contacts.FirstOrDefault(c => c.Id.Equals(id));
            if (contact is null)
                return NotFound();

            contact.FirstName = contactDto.FirstName;
            contact.LastName = contactDto.LastName;
            contact.Email = contactDto.Email;
            contact.MobilePhone = contactDto.MobilePhone;
            contact.Subject = contactDto.Subject;
            contact.Message = contactDto.Message;
            contact.CreateAt = contactDto.CreateAt;
            contact.UpdateAt = contactDto.UpdateAt;

            _Context.SaveChanges();

            return Ok(contact);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            try
            {
                var contact = new Contact() { Id = id };
                _Context.Contacts.Remove(contact);
                _Context.SaveChanges();


            }
            catch (Exception)
            {

                return NotFound();
            }
            return Ok();
        }

    }
}

