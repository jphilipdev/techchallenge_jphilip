using RaceDay.Models;
using System.Threading.Tasks;

namespace RaceDay.DomainServices.Interfaces
{
    public interface ICustomersDomainService
    {
        Task<AllCustomers> GetCustomerDetails();
    }
}