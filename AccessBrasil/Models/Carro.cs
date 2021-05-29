using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccessBrasil.Models
{
    public class Carro
    {
        [Key]
        [Required]
        public int Codigo { get; set; }
        [Required]
        public int MarcaCodigo { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public int Ano { get; set; }
        public string Cor { get; set; }

        public Carro()
        {

        }

        public Carro(int codigo, int marcaCodigo, string modelo, int ano, string cor)
        {
            Codigo = codigo;
            MarcaCodigo = marcaCodigo;
            Modelo = modelo;
            Ano = ano;
            Cor = cor;
        }
    }
}
