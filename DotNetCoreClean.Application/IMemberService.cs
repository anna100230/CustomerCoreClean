using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreClean.Application
{
    public interface IMemberService
    {
        List<Domain.Customer> GetAllCustomer();
        Task<Domain.Customer> ExecuteAsync(int customerNumber);
        Task<bool> UpdateCustomerAsync(int customerNumber, Domain.Customer customer);
        Task<bool> DeleteCustomerAsync(int customerNumber);
    }
}
