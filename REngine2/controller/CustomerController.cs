using Microsoft.AspNetCore.Mvc;
using REngine2.model;
using REngine2.service;

namespace REngine2.controller;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;
    
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    
    [HttpGet]
    public IActionResult GetCustomers()
    {
        return Ok(_customerService.GetCustomers());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCustomer(int id)
    {
        return Ok(_customerService.GetCustomer(id));
    }
    
    [HttpPost]
    public IActionResult AddCustomer([FromBody] Customer customer)
    {
        _customerService.AddCustomer(customer);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(int id, [FromBody] Customer customer)
    {
        _customerService.UpdateCustomer(id, customer);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        _customerService.DeleteCustomer(id);
        return Ok();
    }
}