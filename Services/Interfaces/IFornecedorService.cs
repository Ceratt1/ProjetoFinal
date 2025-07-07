// Services/Interfaces/IFornecedorService.cs
using ProjetoFinal.Models;

namespace ProjetoFinal.Services.Interfaces
{
    public interface IFornecedorService
    {
        Task<List<Fornecedor>> GetAllAsync();
        Task<Fornecedor?> GetByIdAsync(int id);
        Task CreateAsync(Fornecedor fornecedor);
        Task UpdateAsync(Fornecedor fornecedor);
        Task DeleteAsync(int id);
    }
}