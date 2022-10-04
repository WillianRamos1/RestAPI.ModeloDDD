using RestAPI.ModeloDDD.Domain.Contratos;
using RestAPI.ModeloDDD.Domain.Entidades;
using RestAPI.ModeloDDD.Domain.Services.Contratos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPI.ModeloDDD.Domain.Services
{
    public class ServiceProduto : IServiceProduto
    {
        private readonly IProdutoRepository _produtoRepository;

        public ServiceProduto(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _produtoRepository.GetAll();
        }

        public async Task<Produto> GetById(int id)
        {
            return await _produtoRepository.GetAllById(id);
        }

        public async Task Add(Produto produto)
        {
            await _produtoRepository.Adicionar(produto);
        }

        public async Task Update(Produto produto)
        {
            await _produtoRepository.Alterar(produto);
        }

        public async Task Remove(Produto produto)
        {
            await _produtoRepository.Deletar(produto);
        }
    }
}
