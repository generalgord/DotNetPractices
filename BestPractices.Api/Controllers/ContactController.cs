using BestPractices.Api.Models;
using BestPractices.Api.Service.ContactFeatures;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BestPractices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IContactService contactService;

        public ContactController(IConfiguration configuration, IContactService contactService)
        {
            this.configuration = configuration;
            this.contactService = contactService;
        }

        [HttpGet]
        public string Get()
        {
            return configuration["TestMe"].ToString();
        }

        [HttpGet("{id}")]
        public ContactDAO GetContactById(int id)
        {
            return contactService.GetContactById(id);
        }
    }
}
