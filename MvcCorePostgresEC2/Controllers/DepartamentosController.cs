using Microsoft.AspNetCore.Mvc;
using MvcCorePostgresEC2.Models;
using MvcCorePostgresEC2.Repositories;

namespace MvcCorePostgresEC2.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamentos repo;
        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            List<Departamento> departamentos = await this.repo.GetDepartamentosAsync();
            return View(departamentos);
        }
        public async Task<IActionResult> Details(int iddepartamento)
        {
            Departamento dept = await this.repo.FindDepartamentoAsync(iddepartamento);
            return View(dept);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Departamento dept)
        {
            await this.repo.CreateDepartamentoAsync(dept.IdDepartamento
                , dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }
    }
}
