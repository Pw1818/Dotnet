using Microsoft.AspNetCore.Mvc;
using CustomerAPI.Entities;
using CustomerAPI.Repositories;
using CustomerAPI.Entities;
namespace CustomerAPI.Controllers;



[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    
    [HttpGet]
    public List<Customer> GetAll()
    {
        List<Customer> customers = new List<Customer>();
        CustomerRepository repo=new CustomerRepository();
        customers=repo.GetAll();
        return customers;
    }

[HttpGet("{id}")]
    public ActionResult<Customer> GetById(int id)
    {
        CustomerRepository repo = new CustomerRepository();

        Customer customer = repo.GetById(id);

        if (customer == null)
        {
            return NotFound("Customer not found");
        }

        return Ok(customer);
    }
[HttpPost]
    public ActionResult<Customer> Add(Customer customer)
    {
        CustomerRepository repo = new CustomerRepository();

        repo.Create(customer);

        return CreatedAtAction(
            nameof(GetById),
            new { id = customer.Id },
            customer
        );
    }
[HttpPut("{id}")]
    public IActionResult Update(int id, Customer customer)
    {
        if (id != customer.Id)
        {
            return BadRequest("Customer ID mismatch");
        }

        CustomerRepository repo = new CustomerRepository();

        bool result = repo.Update(customer);

        if (!result)
        {
            return NotFound("Customer not found");
        }

        return Ok("Customer updated successfully");
    }
   [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        CustomerRepository repo = new CustomerRepository();

        bool result = repo.Delete(id);

        if (!result)
        {
            return NotFound("Customer not found");
        }

        return Ok("Customer deleted successfully");
    }
}