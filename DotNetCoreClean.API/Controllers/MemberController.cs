using DotNetCoreClean.Application;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Member.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {

        private readonly IMemberService memberService;

        public MembersController(IMemberService memberService)
        {
            this.memberService = memberService;
        }
        // GET: api/<MembersController>
        [HttpGet]
        public ActionResult<IList<DotNetCoreClean.Domain.Customer>> Get()
        {
            return Ok(this.memberService.GetAllCustomer());
        }

        [HttpGet("{customerNumber}")]
        public async Task<IActionResult> GetCustomerDetails(int customerNumber)
        {
            var customer = await memberService.ExecuteAsync(customerNumber);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPut("{customerNumber}")]
        public async Task<IActionResult> UpdateCustomer(int customerNumber, [FromBody] DotNetCoreClean.Domain.Customer customer)
        {
            if (customer == null || customer.CustomerNumber != customerNumber)
            {
                return BadRequest("Invalid customer data.");
            }

            var isUpdated = await memberService.UpdateCustomerAsync(customerNumber, customer);

            if (!isUpdated)
            {
                return NotFound($"Customer with ID {customerNumber} not found.");
            }

            return NoContent(); // 204 No Content indicates successful update with no content returned
        }
        [HttpDelete("{customerNumber}")]
        public async Task<IActionResult> DeleteCustomer(int customerNumber)
        {
            var isDeleted = await memberService.DeleteCustomerAsync(customerNumber);

            if (!isDeleted)
            {
                return NotFound($"Customer with ID {customerNumber} not found.");
            }

            return NoContent(); // 204 No Content indicates successful deletion with no content returned
        }
    }
}