using EstoqueDeSemente.Data;
using EstoqueDeSemente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EstoqueDeSemente.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // Exibir lista de produtos
        public IActionResult Index()
        {
            var produtos = _context.Produtos.ToList();
            return View(produtos);
        }

        // Exibir formulário para adicionar um produto
        public IActionResult Adicionar()
        {
            var produto = new Produto();
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // Exibir formulário de edição
        public ActionResult Editar(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return RedirectToAction("Index");
            }
            return View(produto); // Retorna o produto para a view de edição
        }

        // Salvar as alterações do produto editado
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(produto).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto); // Se houver erros de validação, volta para a view
        }

        // Excluir produto
        [HttpPost, ActionName("DeletarProduto")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarProduto(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edita(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return RedirectToAction("Index");
            }
            return View("Adicionar", produto);
        }
    }
}