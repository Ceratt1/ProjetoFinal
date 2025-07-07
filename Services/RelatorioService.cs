using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Services.Interfaces;
using System.Dynamic;

namespace ProjetoFinal.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly AppDbContext _context;

        public RelatorioService(AppDbContext context)
        {
            _context = context;
        }

        public dynamic GerarRelatorioConsolidado()
        {
            dynamic relatorio = new ExpandoObject();
            
            try
            {
                relatorio.TotalProdutos = _context.Produtos.Count();
                relatorio.ProdutosPorCategoria = _context.Categorias
                    .Include(c => c.Produtos)
                    .Select(c => new
                    {
                        Categoria = c.Nome,
                        Quantidade = c.Produtos.Count
                    }).ToList();

                return relatorio;
            }
            catch
            {
                relatorio.TotalProdutos = 0;
                relatorio.ProdutosPorCategoria = new List<dynamic>();
                return relatorio;
            }
        }
    }
}