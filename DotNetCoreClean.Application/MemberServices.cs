using DotNetCoreClean.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreClean.Application
{
    public class MemberServices : IMemberService
    {
        private readonly IMemberRepository memberRepository;
        public MemberServices(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }
        List<Domain.Customer> IMemberService.GetAllCustomer()
        {
            return this.memberRepository.GetAllCustomer();
        }

        public async Task<Customer> ExecuteAsync(int customerNumber)
        {
            
            return await memberRepository.GetCustomerByNumberAsync(customerNumber);
        }
        public async Task<bool> UpdateCustomerAsync(int customerNumber, Domain.Customer customer)
        {
            var existingCustomer = await memberRepository.GetCustomerByNumberAsync(customerNumber);

            if (existingCustomer == null)
            {
                return false; // Customer not found
            }

            // Update the customer details
            existingCustomer.ContactName = customer.ContactName;
            existingCustomer.PhoneNumber = customer.PhoneNumber;
            existingCustomer.CompanyName = customer.CompanyName;

            await memberRepository.UpdateCustomerAsync(existingCustomer);

            return true;
        }
        public async Task<bool> DeleteCustomerAsync(int customerNumber)
        {
            var customer = await memberRepository.GetCustomerByNumberAsync(customerNumber);

            if (customer == null)
            {
                return false; // Customer not found
            }

            await memberRepository.DeleteCustomerAsync(customer);

            return true;
        }
        }
}
