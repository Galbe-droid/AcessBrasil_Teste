using AccessBrasil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessBrasil.Data
{
    public interface ICarros
    {
        List<Carro> GetCarros();

        Carro GetCarro(int? codigo);
    }
}
