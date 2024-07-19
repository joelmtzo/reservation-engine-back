using REngine2.model;
using REngine2.repository;

namespace REngine2.service.impl;

public class CustomerServiceImpl : ICustomerService
{
    private readonly CustomerRepository _customerRepository;
    
    public CustomerServiceImpl(CustomerRepository customerRepository)
    {
        this._customerRepository = customerRepository;
    }

    public Customer AddCustomer(Customer customer)
    {
        return _customerRepository.Add(customer); 
    }

    public Customer UpdateCustomer(int id, Customer customer)
    {
        return _customerRepository.Update(customer);
    }

    public void DeleteCustomer(int id)
    {
        _customerRepository.Delete(id);
    }

    public Customer GetCustomer(int id)
    {
        return _customerRepository.GetById(id);
    }

    public List<Customer> GetCustomers()
    {
        return _customerRepository.GetAll();
    }
}