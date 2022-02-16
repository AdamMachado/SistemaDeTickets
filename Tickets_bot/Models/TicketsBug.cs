using System;
using System.ComponentModel.DataAnnotations;

namespace Tickets_bot.Models
{
    public class TicketsBug
    {
        [Key]
        [Required]
        public int IdfTicket { get; set; }
        [Required]
        public int IdfPessoaFisica { get; set; }
        [Required]
        public string DesTicket { get; set; }
        [Required]
        public int IdfTicketSituacao { get; set; }
        [Required]
        public DateTime DtaCadastro { get; set; }

        public string NmeTicketResponsavel { get; set; }
        [Required]
        public bool FlgInativo { get; set; }
    }
}
