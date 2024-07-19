using REngine2.model;

namespace REngine2.service;

public interface ICustomerService
{
    public Customer AddCustomer(Customer customer);
    public Customer UpdateCustomer(int id, Customer customer);
    public void DeleteCustomer(int id);
    public Customer GetCustomer(int id);
    public List<Customer> GetCustomers();
}