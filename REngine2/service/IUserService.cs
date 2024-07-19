using REngine2.model;

namespace REngine2.service;

public interface IUserService
{
    public List<User> GetAll();
    public User GetById(int id);
    public void Add(User user);
    public void Update(User user);
    public void Delete(int id);
}