using AccessBrasil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessBrasil.Data
{
    public class CarroDbSearch : ICarros
    {
        private readonly DataContext _context;

        public CarroDbSearch(DataContext context)
        {
            _context = context;
        }

        public Carro GetCarro(int? codigo)
        {
            return _context.DbCarro.Where(obj => obj.Codigo == codigo).FirstOrDefault();
        }

        public List<Carro> GetCarros()
        {
            return _context.DbCarro.ToList();
        }
    }
}
