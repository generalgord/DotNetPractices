using BestPractices.Api.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPractices.Api.Service.ContactFeatures
{
    public interface IContactService
    {
        public ContactDAO GetContactById(int id);
    }
}
