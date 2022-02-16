using System;
using System.Collections.Generic;

namespace Tickets_bot.Models
{
    public class TicketsViewModel
    {
        public int IdfPessoaFisica { get; set; }
        
        public string NmePessoa { get; set;}

        public DateTime DtaCadastro { get; set; }
        public int IdfTicketSituacao { get; set; }
        public bool FlgInativo { get; set; }
        public List<TicketsBug> ListaBugs { get; set; }

        public int PorcentagemTickets { get; set; }
    }
}
