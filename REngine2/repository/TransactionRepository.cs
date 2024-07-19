using Microsoft.EntityFrameworkCore;
using REngine2.config;
using REngine2.model;

namespace REngine2.repository;

public class TransactionRepository
{
    private readonly REngineDbContext _context;
    
    public TransactionRepository(REngineDbContext context)
    {
        _context = context;
    }
    
    public async Task<RTransaction> CreateTransactionAsync(RTransaction rTransaction)
    {
        await _context.Transactions.AddAsync(rTransaction);
        await _context.SaveChangesAsync();
        return rTransaction;
    }
    
    public async Task<RTransaction> GetTransactionByIdAsync(int id)
    {
        return await _context.Transactions.FindAsync(id);
    }
    
    public async Task<IEnumerable<RTransaction>> GetAllTransactionsAsync()
    {
        return await _context.Transactions.ToListAsync();
    }
}