using RestAPI.ModeloDDD.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.ModeloDDD.Domain.Contratos
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> GetAllById(int id);
        Task<Cliente> Adicionar(Cliente cliente);
        Task Alterar(Cliente cliente);
        Task Deletar(Cliente cliente);
    }
}
