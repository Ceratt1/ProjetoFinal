using System.Dynamic;

namespace ProjetoFinal.Services.Interfaces
{
    public interface IRelatorioService
    {
        dynamic GerarRelatorioConsolidado();
    }
}