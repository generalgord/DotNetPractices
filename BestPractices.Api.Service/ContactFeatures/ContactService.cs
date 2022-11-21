using AutoMapper;

using BestPractices.Api.Data.Entities;
using BestPractices.Api.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPractices.Api.Service.ContactFeatures
{
    public class ContactService : IContactService
    {
        private readonly IMapper mapper;

        public ContactService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public ContactDAO GetContactById(int id)
        {
            Contact contact = GetDummyContact(id);

            return mapper.Map<ContactDAO>(contact);

            return new ContactDAO()
            {
                Id = id,
                FullName = $"{contact.FirstName} {contact.LastName}"
            };
        }

        // demo purpose
        private Contact GetDummyContact(int id)
        {
            return new Contact()
            {
                Id = id,
                FirstName = "FirstT",
                LastName = "LastT",
                PhoneNumber = "05554448899",
                Address = "Test Blv. 12094, 45, TR",
                City = "Test City",
                Email = "test@mail.com"
            };
        }
    }
}
