using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessBrasil.Data
{
    public class MarcaMainFunctions : IMainFunctions
    {
        private readonly DataContext _context;

        public MarcaMainFunctions(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T item) where T : class
        {
            _context.Add(item);
        }

        public void Delete<T>(T item) where T : class
        {
            _context.Remove(item);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T item) where T : class
        {
            _context.Update(item);
        }
    }
}
