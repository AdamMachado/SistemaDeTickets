using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tickets_bot.Models;

namespace Tickets_bot.Controllers
{
    public class TicketsController : Controller
    {
        private readonly Contexto _contexto;
       public TicketsController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> ListagemTickets(int idfPessoaFisica)
        {
            PessoaFisica pessoaFisica = await _contexto.Tab_pessoa_fisica.FindAsync(idfPessoaFisica);
            TicketsViewModel ticketsViewModel = new TicketsViewModel
            {
                IdfPessoaFisica = idfPessoaFisica,
                NmePessoa = pessoaFisica.NmePessoa,
                ListaBugs = await _contexto.Tab_tickets_bugs.Where(c => c.IdfPessoaFisica == idfPessoaFisica).ToListAsync(),



            };
            return View(ticketsViewModel);
        }
        [HttpGet]
        public IActionResult NovoTicket(int idfPessoaFisica)
        {
            TicketsBug ticketsBug = new TicketsBug
            {
                IdfPessoaFisica = idfPessoaFisica
            };
            return View(ticketsBug);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NovoTicket(TicketsBug ticketsBug)
        {
            if(ModelState.IsValid)
            {
                await _contexto.AddAsync(ticketsBug);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(ListagemTickets),new { idfPessoaFisica =ticketsBug.IdfPessoaFisica});
            }
            return View(ticketsBug);
        }

    }
}
