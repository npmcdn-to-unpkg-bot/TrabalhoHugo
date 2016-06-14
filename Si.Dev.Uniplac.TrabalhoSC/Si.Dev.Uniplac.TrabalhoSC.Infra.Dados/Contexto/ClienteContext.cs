using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Contexto
{
    class ClienteContext : DbContext
    {
        public ClienteContext() : base("ClienteDB")
        {
        }

        public DbSet<Carro> Produtos { get; set; }
        public DbSet<Servico> Clientes { get; set; }
    }
}
