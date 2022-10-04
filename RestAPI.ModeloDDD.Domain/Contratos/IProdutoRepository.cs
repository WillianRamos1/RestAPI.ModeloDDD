using RestAPI.ModeloDDD.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.ModeloDDD.Domain.Contratos
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetAll();
        Task<Produto> GetAllById(int id);
        Task<Produto> Adicionar(Produto produto);
        Task Alterar(Produto produto);
        Task Deletar(Produto produto);
    }
}
