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
    public class ApplicationServiceProduto : IApplicationServiceProduto
    {
        private readonly IServiceProduto _serviceProduto;
        private readonly IMapper _mapper;

        public ApplicationServiceProduto(IServiceProduto serviceProduto, IMapper mapper)
        {
            _serviceProduto = serviceProduto;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoDto>> GetAll()
        {
            var produtos = await _serviceProduto.GetAll();
            var produtoDto = _mapper.Map<IEnumerable<ProdutoDto>>(produtos);
            return produtoDto;
        }

        public async Task<ProdutoDto> GetById(int id)
        {
            var produto = await _serviceProduto.GetById(id);
            var produtoDto = _mapper.Map<ProdutoDto>(produto);
            return produtoDto;
        }

        public async Task<ProdutoDto> Adicionar(ProdutoDto produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            await _serviceProduto.Add(produto);
            return produtoDto;
        }

        public async Task Alterar(ProdutoDto produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            await _serviceProduto.Update(produto);
        }

        public async Task Deletar(int id)
        {
            var deletar = await _serviceProduto.GetById(id);
            var produto = _mapper.Map<Produto>(deletar);
            await _serviceProduto.Remove(produto);
        }
    }
}
