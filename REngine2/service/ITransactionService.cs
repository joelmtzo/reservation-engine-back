using REngine2.model;

namespace REngine2.service;

public interface ITransactionService
{
    Task<RTransaction> CreateTransactionAsync(RTransaction rTransaction);
    Task<RTransaction> GetTransactionByIdAsync(int id);
    Task<IEnumerable<RTransaction>> GetAllTransactionsAsync();
}