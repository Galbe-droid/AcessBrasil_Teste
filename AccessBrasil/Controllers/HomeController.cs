using AccessBrasil.Data;
using AccessBrasil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AccessBrasil.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        private readonly IMainFunctions _mainFunctions;
        private readonly ICarros _interfaceCarro;
        private readonly IMarcas _interfaceMarca;

        public HomeController(ILogger<HomeController> logger, DataContext context, IMainFunctions mainFuncion, ICarros interfaceCarro, IMarcas interfaceMarca)
        {
            _logger = logger;
            _context = context;
            _mainFunctions = mainFuncion;
            _interfaceCarro = interfaceCarro;
            _interfaceMarca = interfaceMarca;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CarroList()
        {
            var result = _interfaceCarro.GetCarros();
            return View(result);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (_interfaceMarca.GetMarcas().Count() <= 0)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpPost]
        public ActionResult Create(Carro carro)
        {
            if (ModelState.IsValid)
            {
                if (_interfaceMarca.GetMarcas().Any(obj => obj.Codigo == carro.MarcaCodigo) == false || _interfaceMarca.GetMarcas().Count() <= 0)
                {
                    return View("Error");
                }
                else
                {
                    _mainFunctions.Add(carro);

                    _mainFunctions.SaveChanges();

                    return View("Sucesso");
                }

            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if(id == null || _interfaceCarro.GetCarro(id) == null)
            {
                return View("Error");
            }

            var result = _interfaceCarro.GetCarro(id);

            return View(result);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = _interfaceCarro.GetCarro(id);

            _mainFunctions.Delete(result);
            _mainFunctions.SaveChanges();
            return RedirectToAction("Sucesso");
        }

        [HttpGet]
        public ActionResult Look(int? id)
        {
            if (id == null || _interfaceCarro.GetCarro(id) == null)
            {
                return View("Error");
            }

            var result = _interfaceCarro.GetCarro(id);

            return View(result);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null || _interfaceCarro.GetCarro(id) == null)
            {
                return View("Error");
            }

            var result = _interfaceCarro.GetCarro(id);

            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Update(int id)
        {
            if(_interfaceCarro.GetCarro(id) == null)
            {
                return View("Error");
            }

            if(ModelState.IsValid)
            {
                var carro = _interfaceCarro.GetCarro(id);
                _mainFunctions.Update(carro);
                await _mainFunctions.SaveChanges();
            }

            return View("Sucesso");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
