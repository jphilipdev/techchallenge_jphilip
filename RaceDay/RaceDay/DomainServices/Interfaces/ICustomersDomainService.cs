using RaceDay.Models;
using System.Collections.Generic;

namespace RaceDay.DomainServices.Interfaces
{
    public interface ICustomersDomainService
    {
        ICollection<CustomerDetails> GetCustomerDetails();
    }
}