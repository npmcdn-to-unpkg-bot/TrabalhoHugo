using Si.Dev.Uniplac.TrabalhoSC.Dominio.Contratos;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Contexto;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private ClienteContext _contexto;

        public ClienteRepositorio()
        {
            _contexto = new ClienteContext();
        }

        public Cliente Adicionar(Cliente cliente)
        {
            var resultado = _contexto.Clientes.Add(cliente);
            _contexto.SaveChanges();
            return resultado;
        }

        public Cliente Atualizar(Cliente cliente)
        {

            var dbCliente = _contexto.Clientes
                       .Include(x => x.Carro)
                       .Single(c => c.Id == cliente.Id);

            _contexto.Entry(dbCliente).CurrentValues.SetValues(cliente);
            _contexto.Entry(dbCliente.Carro).CurrentValues.SetValues(cliente.Carro);

            _contexto.SaveChanges();

            return cliente;
        }

        public Cliente Buscar(int id)
        {
            return _contexto.Clientes.Include(c => c.Carro).FirstOrDefault(i => i.Id == id);
        }

        public List<Cliente> BuscarTodos()
        {
            return _contexto.Clientes
                .Include(c => c.Carro)
                .ToList();
        }

        public void Deletar(Cliente cliente)
        {
            var entry = _contexto.Entry(cliente);
            entry.State = System.Data.Entity.EntityState.Deleted;
            _contexto.SaveChanges();
        }
    }
}