using RestAPI.ModeloDDD.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.ModeloDDD.Domain.Services.Contratos
{
    public interface IServiceCliente
    {
        Task<IEnumerable<Cliente>> GetAll();

        Task<Cliente> GetById(int id);

        Task Add(Cliente cliente);

        Task Update(Cliente cliente);

        Task Remove(Cliente cliente);
    }
}
