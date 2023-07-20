using Microsoft.EntityFrameworkCore;
using registroClientes.Domain.Interfaces;
using registroClientes.Domain.Model;
using registroClientes.Infra.Data.Context;

namespace registroClientes.Infra.Data.Repository;

public class RegistroRepository : IRegistroRepository
{
    private readonly ApplicationDbContext _context;

    public RegistroRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Cliente> AtualizarEmailAsync(Cliente cliente)
    {
        _context.Update(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente> AtualizarNumeroContatoAsync(Cliente cliente)
    {
        Cliente existeCliente = await _context.Clientes.AsNoTracking().Include(t => t.Telefones).FirstOrDefaultAsync(c => c.Id == cliente.Id);

        if (existeCliente is not null)
        {
            var existeContato = existeCliente.Telefones.FirstOrDefault(t => t.Id == cliente.Id);

            if (existeContato is not null)
            {
                cliente.Telefones.ForEach(t =>
                {
                    existeContato.DDD_Numero = t.DDD_Numero;
                    existeContato.Tipo = t.Tipo;
                });
                await _context.SaveChangesAsync();
            }
        }
        return existeCliente;
    }

    public async Task<Cliente> BuscarPorNumeroContatoAsync(string numeroContato)
    {
        Cliente cliente = await _context.Clientes
            .Include(c => c.Telefones)
            .FirstOrDefaultAsync(c => c.Telefones.Any(p => p.DDD_Numero == numeroContato));

        return cliente;
    }

    public async Task<IEnumerable<Cliente>> BuscarTodosClientesAsync()
    {
        return await _context.Clientes.AsNoTracking().Include(c => c.Telefones).ToListAsync();
    }

    public async Task<Cliente> CadastrarClienteAsync(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<bool> DeletarPorEmailAsync(string email)
    {
        Cliente cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == email);

        if (cliente is null)
            return false;

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();

        return true;
    }
}