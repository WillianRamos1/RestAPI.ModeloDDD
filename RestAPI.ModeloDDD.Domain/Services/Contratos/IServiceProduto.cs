using RestAPI.ModeloDDD.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.ModeloDDD.Domain.Services.Contratos
{
    public interface IServiceProduto
    {
        Task<IEnumerable<Produto>> GetAll();

        Task<Produto> GetById(int id);

        Task Add(Produto produto);

        Task Update(Produto produto);

        Task Remove(Produto produto);
    }
}
