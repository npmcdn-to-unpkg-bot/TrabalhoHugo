using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using System.Data.Entity;

namespace Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Contexto
{
    public class ClienteContext : DbContext
    {
        public ClienteContext() : base("OficinaDB")
        {
        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}