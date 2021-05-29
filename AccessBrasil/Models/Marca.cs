using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccessBrasil.Models
{
    public class Marca
    {
        [Key]
        [Required]
        public int Codigo { get; set; }
        [Required]
        public string Nome { get; set; }

        public Marca()
        {
                
        }

        public Marca(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }
    }
}
