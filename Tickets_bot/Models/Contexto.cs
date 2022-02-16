using Microsoft.EntityFrameworkCore;

namespace Tickets_bot.Models
{
    public class Contexto :DbContext

    {
        public DbSet<PessoaFisica> Tab_pessoa_fisica { get; set; }
        public DbSet<TicketsBug> Tab_tickets_bugs { get; set; }
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {

        }
    }
}
