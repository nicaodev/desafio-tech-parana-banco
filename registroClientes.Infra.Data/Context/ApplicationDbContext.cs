using Microsoft.EntityFrameworkCore;
using registroClientes.Domain.Model;

namespace registroClientes.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Telefone> Telefones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
        modelBuilder.Entity<Telefone>().HasKey(t => t.Id);

        modelBuilder.Entity<Cliente>()
            .HasMany(c => c.Telefones)  // Um cliente tem muitos telefones
            .WithOne(p => p.Cliente)  // Um telefone pertence a um único cliente
            .HasForeignKey(p => p.ClienteId); // Chave estrangeira para a relação
    }
}