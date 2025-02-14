using E_Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Domain.Repositories.Interfaces
{
    public interface IContactUsRepository
    {
        public bool SendMessage(ContactUsMessage message);
        public bool UpdateMessage(ContactUsMessage message);
        public IEnumerable<ContactUsMessage> GetAll();
        public ContactUsMessage GetMessageById(int Id);
       
        

    }
}
