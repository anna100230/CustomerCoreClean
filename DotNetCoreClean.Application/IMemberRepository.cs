using DotNetCoreClean.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreClean.Application
{
    public interface IMemberRepository
    {
        List<Domain.Customer> GetAllCustomer();
        Task<Customer> GetCustomerByNumberAsync(int customerNumber);
        Task UpdateCustomerAsync(Domain.Customer customer);
        Task DeleteCustomerAsync(Domain.Customer customer);
    }
}
