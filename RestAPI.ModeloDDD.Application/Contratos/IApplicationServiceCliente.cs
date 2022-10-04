using RestAPI.ModeloDDD.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.ModeloDDD.Application.Contratos
{
    public interface IApplicationServiceCliente
    {
        Task<IEnumerable<ClienteDto>> GetAll();
        Task<ClienteDto> GetById(int id);

        Task<ClienteDto> Adicionar(ClienteDto clienteDto);
        Task Alterar(ClienteDto clienteDto);
        Task Deletar(int id);
    }
}
