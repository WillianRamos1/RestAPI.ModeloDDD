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
    public class ProdutosController : ControllerBase
    {
        private readonly IApplicationServiceProduto _applicationServiceProduto;

        public ProdutosController(IApplicationServiceProduto applicationServiceProduto)
        {
            _applicationServiceProduto = applicationServiceProduto;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var produtos = await _applicationServiceProduto.GetAll();

                return produtos.Any() ? Ok(produtos) : BadRequest("Produtos Não Encontrados.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar mostrar Produtos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var produto = await _applicationServiceProduto.GetById(id);
                if (produto == null) return BadRequest("Produto Não Encontrado.");
                return Ok(produto);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar mostrar Produto {id}. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProdutoDto produtoDto)
        {
            try
            {
                if (produtoDto == null) return BadRequest();
                await _applicationServiceProduto.Adicionar(produtoDto);
                return Ok("Produto Adicionado com Sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Adicionar o Produto. Erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProdutoDto produtoDto)
        {
            try
            {
                if (produtoDto == null) return NotFound();
                await _applicationServiceProduto.Alterar(produtoDto);
                return Ok(produtoDto);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Alterar o Produto. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _applicationServiceProduto.Deletar(id);
                return Ok("Produto Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar Excluir o Produto. Erro: {ex.Message}");
            }
        }
    }
}
