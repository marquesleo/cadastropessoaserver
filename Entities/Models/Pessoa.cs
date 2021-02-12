using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Extensions;

namespace Entities.Models
{
    [Table("pessoa")]
    public class Pessoa:IEntity
    {
        [Key]
        public Guid Id { get; set ; }
       
        
        public string nome { get; set; }

        public string CPF { get; set; }

        public string email { get; set; }

        public string telefone { get; set; }

        public string sexo { get; set; }

        public DateTime dataNascimento { get; set; }

        public void Map(Pessoa pessoa)
        {
            PessoaExtensions.Map(this, pessoa);
        }
    }
}
