using RaceDay.Models;
using System.Threading.Tasks;

namespace RaceDay.DomainServices.Interfaces
{
    public interface ICustomerDomainService
    {
        Task<AllCustomers> GetCustomerDetails();
    }
}