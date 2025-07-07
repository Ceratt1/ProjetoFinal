using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Data;
using ProjetoFinal.Models;
using ProjetoFinal.Services.Interfaces;
using System.Threading.Tasks;

namespace ProjetoFinal.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _service;
        private readonly AppDbContext _context;

        public ProdutosController(IProdutoService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var produto = await _service.GetByIdAsync(id.Value);
            if (produto == null) return NotFound();

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewBag.Categorias = _context.Categorias.ToList();
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(produto);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = _context.Categorias.ToList();
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var produto = await _service.GetByIdAsync(id.Value);
            if (produto == null) return NotFound();

            ViewBag.Categorias = _context.Categorias.ToList();
            return View(produto);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            if (id != produto.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(produto);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = _context.Categorias.ToList();
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var produto = await _service.GetByIdAsync(id.Value);
            if (produto == null) return NotFound();

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}