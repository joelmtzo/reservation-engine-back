using REngine2.config;
using REngine2.model;

namespace REngine2.repository;

public class UserRepository
{
    private readonly REngineDbContext _context;
    
    public UserRepository(REngineDbContext context)
    {
        _context = context;
    }
    
    public List<User> GetAll()
    {
        return _context.Users.ToList();
    }
    
    public User GetById(int id) 
    {
        return _context.Users.Find(id);
    }
    
    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
    
    public void Update(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }
    
    public void Delete(int id)
    {
        var user = _context.Users.Find(id);
        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}