using System.Collections.Generic;
using System.Threading.Tasks;
using ProjetoFinal.Models;

namespace ProjetoFinal.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<List<Produto>> GetAllAsync();
        Task<Produto> GetByIdAsync(int id);
        Task CreateAsync(Produto produto);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(int id);
    }
}