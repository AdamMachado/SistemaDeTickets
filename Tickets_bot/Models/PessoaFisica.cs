using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tickets_bot.Models
{
    public class PessoaFisica
    {
        [Key]
        [Required]
        public int IdfPessoaFisica { get; set; }
        [Required]
        public long NumCpf { get; set; }
        [Required]
        public string NmePessoa { get; set; }
        public DateTime DtaNascimento { get; set; }
        public string EmlPessoa { get; set; }
        [Required]
        public DateTime DtaCadastro { get; set; }
        [Required]
        public bool FlgInativo { get; set; }
        [Required]
        public string EmlAccount { get; set; }
        public ICollection<TicketsBug> Tab_tickets_bugs { get; set; }

    }
}
