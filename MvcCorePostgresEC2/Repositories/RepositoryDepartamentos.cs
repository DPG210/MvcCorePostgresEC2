using Microsoft.EntityFrameworkCore;
using MvcCorePostgresEC2.Data;
using MvcCorePostgresEC2.Models;

namespace MvcCorePostgresEC2.Repositories
{
    public class RepositoryDepartamentos
    {
        private HospitalContext context;
        public RepositoryDepartamentos(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> FindDepartamentoAsync(int idDepartamento)
        {
            return await this.context.Departamentos
                .Where(x => x.IdDepartamento == idDepartamento).FirstOrDefaultAsync();
        }

        public async Task CreateDepartamentoAsync
            (int idDepartamento, string nombre, string localidad)
        {
            Departamento departamento = new Departamento
            {
                IdDepartamento = idDepartamento,
                Nombre = nombre,
                Localidad = localidad
            };
            await this.context.Departamentos.AddAsync(departamento);
            await this.context.SaveChangesAsync();
        }
    }
}
