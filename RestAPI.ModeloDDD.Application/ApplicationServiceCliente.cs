using AutoMapper;
using RestAPI.ModeloDDD.Application.Contratos;
using RestAPI.ModeloDDD.Application.Dtos;
using RestAPI.ModeloDDD.Domain.Entidades;
using RestAPI.ModeloDDD.Domain.Services.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.ModeloDDD.Application
{
    public class ApplicationServiceCliente : IApplicationServiceCliente
    {
        private readonly IServiceCliente _serviceCliente;
        private readonly IMapper _mapper;

        public ApplicationServiceCliente(IServiceCliente serviceCliente, IMapper mapper)
        {
            _serviceCliente = serviceCliente;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDto>> GetAll()
        {
            var clientes = await _serviceCliente.GetAll();
            var clienteDto = _mapper.Map<IEnumerable<ClienteDto>>(clientes);
            return clienteDto;
        }

        public async Task<ClienteDto> GetById(int id)
        {
            var clientes = await _serviceCliente.GetById(id);
            var clienteDto = _mapper.Map<ClienteDto>(clientes);
            return clienteDto;
        }

        public async Task<ClienteDto> Adicionar(ClienteDto clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            await _serviceCliente.Add(cliente);
            return clienteDto;
        }

        public async Task Alterar(ClienteDto clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            await _serviceCliente.Update(cliente);
        }

        public async Task Deletar(int id)
        {
            var deletar = await _serviceCliente.GetById(id);
            var cliente = _mapper.Map<Cliente>(deletar);
            await _serviceCliente.Remove(cliente);
        }
    }
}
