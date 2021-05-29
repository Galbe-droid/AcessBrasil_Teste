using AccessBrasil.Data;
using AccessBrasil.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessBrasil.Controllers
{
    public class MarcaController : Controller
    {
        private readonly DataContext _context;
        private readonly IMainFunctions _mainFunctions;
        private readonly ICarros _interfaceCarro;
        private readonly IMarcas _interfaceMarca;

        public MarcaController(DataContext context, IMainFunctions mainFuncion, ICarros interfaceCarro, IMarcas interfaceMarca)
        {
            _context = context;
            _mainFunctions = mainFuncion;
            _interfaceCarro = interfaceCarro;
            _interfaceMarca = interfaceMarca;
        }

        public ActionResult MarcaLista()
        {
            var results = _interfaceMarca.GetMarcas();
            return View(results);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<ActionResult> Create(Marca marca)
        {
            if(ModelState.IsValid)
            {
                /*marca.Codigo = _context.DbMarca.Count() + 1;
                while (_interfaceMarca.GetMarcas().Any(obj => obj.Codigo == marca.Codigo) == true)
                {
                    marca.Codigo++;
                }*/

                _mainFunctions.Add(marca);

                await _mainFunctions.SaveChanges();

                return View("MarcaLista");
            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null || _interfaceMarca.GetMarca(id) == null)
            {
                return View("Error");
            }

            var result = _interfaceMarca.GetMarca(id);

            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var result = _interfaceMarca.GetMarca(id);

            _mainFunctions.Delete(result);
            await _mainFunctions.SaveChanges();
            return View("Sucesso");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null || _interfaceMarca.GetMarca(id) == null)
            {
                return View("Error");
            }

            var result = _interfaceMarca.GetMarca(id);

            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Update(int id)
        {
            if (_interfaceMarca.GetMarca(id) == null)
            {
                return View("Error");
            }

            if (ModelState.IsValid)
            {
                var marca = _interfaceMarca.GetMarca(id);
                _mainFunctions.Update(marca);
                await _mainFunctions.SaveChanges();
            }

            return View("Sucesso");
        }

        [HttpGet]
        public ActionResult Look(int? id)
        {
            if (id == null || _interfaceMarca.GetMarca(id) == null)
            {
                return View("Error");
            }

            var result = _interfaceMarca.GetMarca(id);

            return View(result);
        }
    }
}
