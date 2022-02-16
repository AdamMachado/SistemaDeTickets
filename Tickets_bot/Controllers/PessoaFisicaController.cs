using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Tickets_bot.Models;

namespace Tickets_bot.Controllers
{
    public class PessoaFisicaController : Controller
    {

        private readonly Contexto _contexto;

        public PessoaFisicaController(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<IActionResult> ListagemPessoas()
        {
            return View(await _contexto.Tab_pessoa_fisica.ToListAsync());
        }
        [HttpGet]
        public IActionResult NovaPessoa()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NovaPessoa(PessoaFisica Pessoa)
        {
            if (ModelState.IsValid)
            {
                await _contexto.AddAsync(Pessoa);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(ListagemPessoas));
            }
            return View(Pessoa);
        }
        [HttpGet] 
        public async Task<IActionResult>AtualizarPessoa(int idfPessoaFisica)

        {
            PessoaFisica pessoaFisica = await _contexto.Tab_pessoa_fisica.FindAsync(idfPessoaFisica);

            if(pessoaFisica==null)
            {
                return NotFound();

            }
            return View(pessoaFisica);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtualizarPessoa(int idfPessoaFisica, PessoaFisica pessoaFisica)
        {
            if (idfPessoaFisica != pessoaFisica.IdfPessoaFisica)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _contexto.Update(pessoaFisica);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(ListagemPessoas));
            }
            return View(pessoaFisica);
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirPessoa(int idfPessoaFisica)
        {
            PessoaFisica pessoaFisica = await _contexto.Tab_pessoa_fisica.FindAsync(idfPessoaFisica);
            _contexto.Tab_pessoa_fisica.Remove(pessoaFisica);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(ListagemPessoas));
        }

    }
}
