using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Services.Interfaces;

namespace ProjetoFinal.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly IRelatorioService _relatorioService;

        public RelatoriosController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        public IActionResult Index()
        {
            try
            {
                var relatorio = _relatorioService.GerarRelatorioConsolidado();
                return View(relatorio);
            }
            catch (Exception ex)
            {
                // Logar o erro (implemente seu logger)
                Console.WriteLine($"Erro ao gerar relatório: {ex.Message}");
                return View("Error");
            }
        }
    }
}