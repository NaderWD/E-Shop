using E_Shop.Domain.Contracts.ContactUsCont;
using E_Shop.Domain.Models.ContactUsModels;

namespace E_Shop.Infra.Data.Repositories.ContactUsRepo
{
    public class ContactUsRepository(ShopDbContext context) : IContactUsRepository
    {
        private readonly ShopDbContext _context = context;

        public IEnumerable<ContactUsMessage> GetAll()
        {
            return _context.ContactUsMessages.ToList();
        }

        public ContactUsMessage GetMessageById(int Id)
        {
            return _context.ContactUsMessages.Find(Id);
        }

        public bool SendMessage(ContactUsMessage message)
        {
            _context.ContactUsMessages.Add(message);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateMessage(ContactUsMessage message)
        {
            _context.ContactUsMessages.Update(message);
            _context.SaveChanges();
            return true;
        }
    }
}
