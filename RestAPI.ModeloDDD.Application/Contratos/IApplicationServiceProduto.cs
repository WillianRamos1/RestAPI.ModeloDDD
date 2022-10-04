using RestAPI.ModeloDDD.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.ModeloDDD.Application.Contratos
{
    public interface IApplicationServiceProduto
    {
        Task<IEnumerable<ProdutoDto>> GetAll();
        Task<ProdutoDto> GetById(int id);

        Task<ProdutoDto> Adicionar(ProdutoDto produtoDto);
        Task Alterar(ProdutoDto produtoDto);
        Task Deletar(int id);
    }
}
