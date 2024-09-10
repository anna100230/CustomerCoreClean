using DotNetCoreClean.Application;
using DotNetCoreClean.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreClean.Infrastructure
{

    public class MemberRepository : IMemberRepository
    {
        public static List<Domain.Customer> lstMembers = new List<Domain.Customer>()
        {
           new Domain.Customer{  CustomerNumber =1 ,ContactName= "Sini", PhoneNumber ="123" , CompanyName="Bofor"},
           new Domain.Customer{  CustomerNumber =2 ,ContactName= "Mahesh", PhoneNumber ="456" , CompanyName="Bofor"},
           new Domain.Customer{  CustomerNumber =3 ,ContactName= "Elisha", PhoneNumber ="666" , CompanyName="Bofor"},
           new Domain.Customer{  CustomerNumber =4 ,ContactName= "Anna", PhoneNumber ="666" , CompanyName="Bofor"},
           new Domain.Customer{  CustomerNumber =5 ,ContactName= "Muna", PhoneNumber ="66" , CompanyName="Bofor"},
           new Domain.Customer{  CustomerNumber =6 ,ContactName= "Mita", PhoneNumber ="666" , CompanyName="Bofor"}
        };
        public List<Domain.Customer> GetAllCustomer()
        {
            return lstMembers;
        }

        public async Task<Domain.Customer> GetCustomerByNumberAsync(int customerNumber)
        {
            await Task.Delay(10); // Simulate async operation for demonstration purposes

            // Retrieve customer by CustomerNumber
            return lstMembers.FirstOrDefault(c => c.CustomerNumber == customerNumber);
        }
        public async Task UpdateCustomerAsync(Domain.Customer customer)
        {
            await Task.Delay(10); // Simulate async operation

            var existingCustomer = lstMembers.FirstOrDefault(c => c.CustomerNumber == customer.CustomerNumber);
            if (existingCustomer != null)
            {
                existingCustomer.ContactName = customer.ContactName;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                existingCustomer.CompanyName = customer.CompanyName;
            }
        }
        public async Task DeleteCustomerAsync(Domain.Customer customer)
        {
            await Task.Delay(10); // Simulate async operation
            lstMembers.Remove(customer);
        }

        // Correct implementation of the interface method
        async Task<Customer> IMemberRepository.AddCustomerAsync(Customer customer)
        {
            await Task.Delay(10); // Simulate async operation

            // Check if the customer already exists based on CustomerNumber
            var existingCustomer = lstMembers.FirstOrDefault(c => c.CustomerNumber == customer.CustomerNumber);
            if (existingCustomer != null)
            {
                throw new ArgumentException("Customer with the same CustomerNumber already exists.");
            }

            // Add the new customer to the list
            lstMembers.Add(customer);

            // Return the added customer
            return customer;
        }

    }
}

