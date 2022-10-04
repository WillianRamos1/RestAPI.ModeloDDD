using Microsoft.EntityFrameworkCore;
using RestAPI.ModeloDDD.Domain.Contratos;
using RestAPI.ModeloDDD.Domain.Entidades;
using RestAPI.ModeloDDD.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.ModeloDDD.Infrastructure.Repositorios
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DatabaseContext _context;

        public ProdutoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> GetAllById(int id)
        {
            return await _context.Produtos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Produto> Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task Alterar(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
