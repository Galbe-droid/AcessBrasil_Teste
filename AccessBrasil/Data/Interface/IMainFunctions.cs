using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessBrasil.Data
{
    public interface IMainFunctions
    {
        void Add<T>(T item) where T : class;
        void Update<T>(T item) where T : class;
        void Delete<T>(T item) where T : class;
        Task<bool> SaveChanges();
    }
}
