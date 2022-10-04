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
    public class ClienteRepository : IClienteRepository
    {
        private readonly DatabaseContext _context;

        public ClienteRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetAllById(int id)
        {
            return await _context.Clientes.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Cliente> Adicionar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task Alterar(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
