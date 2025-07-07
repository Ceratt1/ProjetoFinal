using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Blog
        public async Task<IActionResult> Index()
        {
            var posts = await _context.BlogPosts
                .OrderByDescending(p => p.DataPublicacao)
                .ToListAsync();
            return View(posts);
        }

        // GET: Blog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.BlogPosts
                .Include(p => p.Comentarios)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Blog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Conteudo,Autor")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                blogPost.DataPublicacao = DateTime.Now;
                _context.Add(blogPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogPost);
        }

        // POST: Blog/AddComment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(int blogPostId, string texto, string autor)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                TempData["ErrorMessage"] = "O comentário não pode estar vazio";
                return RedirectToAction("Details", new { id = blogPostId });
            }

            var comentario = new Comentario
            {
                BlogPostId = blogPostId,
                Texto = texto,
                Autor = string.IsNullOrEmpty(autor) ? "Anônimo" : autor,
                DataComentario = DateTime.Now
            };

            _context.Add(comentario);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = blogPostId });
        }
    }
}