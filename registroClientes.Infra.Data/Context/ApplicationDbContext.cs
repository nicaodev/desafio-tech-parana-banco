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
        modelBuilder.Entity<Telefone>()
            .HasOne(_ => _.Cliente)  // Um telefone pertence a um único cliente
            .WithMany(p => p.Telefones) // Um cliente tem muitos telefones
            .HasForeignKey(p => p.ClienteId) // Chave estrangeira para a relação
            .OnDelete(DeleteBehavior.Cascade);
    }
}