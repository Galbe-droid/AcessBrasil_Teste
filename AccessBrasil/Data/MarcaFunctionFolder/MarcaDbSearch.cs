using AccessBrasil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessBrasil.Data
{
    public class MarcaDbSearch : IMarcas
    {
        private readonly DataContext _context;

        public MarcaDbSearch(DataContext context)
        {
            _context = context;

        }
        public Marca GetMarca(int? codigo)
        {
            return _context.DbMarca.Where(obj => obj.Codigo == codigo).FirstOrDefault();
        }

        public List<Marca> GetMarcas()
        {
            return _context.DbMarca.ToList();
        }
    }
}
