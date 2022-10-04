using RestAPI.ModeloDDD.Domain.Contratos;
using RestAPI.ModeloDDD.Domain.Entidades;
using RestAPI.ModeloDDD.Domain.Services.Contratos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI.ModeloDDD.Domain.Services
{
    public class ServiceCliente : IServiceCliente
    {
        private readonly IClienteRepository _clienteRepository;

        public ServiceCliente(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _clienteRepository.GetAllById(id);
        }

        public async Task Add(Cliente cliente)
        {
            await _clienteRepository.Adicionar(cliente);
        }

        public async Task Update(Cliente cliente)
        {
            await _clienteRepository.Alterar(cliente);
        }

        public async Task Remove(Cliente cliente)
        {
            await _clienteRepository.Deletar(cliente);
        }
    }
}
