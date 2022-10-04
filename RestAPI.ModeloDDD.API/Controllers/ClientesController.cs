using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.ModeloDDD.Application.Contratos;
using RestAPI.ModeloDDD.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.ModeloDDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IApplicationServiceCliente _applicationServiceCliente;

        public ClientesController(IApplicationServiceCliente applicationServiceCliente)
        {
            _applicationServiceCliente = applicationServiceCliente;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {            
                var clientes = await _applicationServiceCliente.GetAll();

                return clientes.Any() ? Ok(clientes) : BadRequest("Clientes Não Encontrados.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar mostrar Clientes. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var cliente = await _applicationServiceCliente.GetById(id);
                if (cliente == null) return BadRequest("Cliente Não Encontrado.");
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar mostrar Cliente {id}. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteDto clienteDto)
        {
            try
            {            
                if (clienteDto == null) return BadRequest();
               await _applicationServiceCliente.Adicionar(clienteDto);
                return Ok("Cliente Adicionado com Sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Adicionar o Cliente. Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ClienteDto clienteDto)
        {
            try
            {
                if (clienteDto == null) return NotFound();
                await _applicationServiceCliente.Alterar(clienteDto);
                return Ok(clienteDto);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Alterar o Cliente. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _applicationServiceCliente.Deletar(id);
                return Ok("Cliente Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Excluir o Cliente. Erro: {ex.Message}");
            }
        }
    }
}
