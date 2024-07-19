using REngine2.config;
using REngine2.model;

namespace REngine2.repository;

public class CustomerRepository
{
    private readonly REngineDbContext _context;

    public CustomerRepository(REngineDbContext context)
    {
        _context = context;
    }
    
    public List<Customer> GetAll()
    {
        return _context.Customers.ToList();
    }
    
    public Customer GetById(int id) 
    {
        return _context.Customers.Find(id);
    }
    
    public Customer Add(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return customer;
    }
    
    public Customer Update(Customer customer)
    {
        _context.Customers.Update(customer);
        _context.SaveChanges();
        return customer;
    }
    
    public void Delete(int id)
    {
        var customer = _context.Customers.Find(id);
        _context.Customers.Remove(customer);
        _context.SaveChanges();
    }
}