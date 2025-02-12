using E_Shop.Domain.Models;
using E_Shop.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Infra.Data.Repositories.Implementations
{
    public class ContactUsRepository(ShopDbContext context) : IContactUsRepository
    {
        private readonly ShopDbContext _context = context;

        public IEnumerable<ContactUsMessage> GetAll()
        {
            return _context.ContactUsMessages;
        }

        public bool SendMessage(ContactUsMessage message)
        {
            _context.ContactUsMessages.Add(message);
            _context.SaveChanges();
            return true;
        }
    }
}
