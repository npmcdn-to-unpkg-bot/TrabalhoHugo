using Si.Dev.Uniplac.TrabalhoSC.Dominio.Contratos;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Contexto;
using System.Collections.Generic;
using System.Linq;

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
            var entry = _contexto.Entry<Cliente>(cliente);
            entry.State = System.Data.Entity.EntityState.Modified;
            _contexto.SaveChanges();

            return cliente;
        }

        public Cliente Buscar(int id)
        {
            return _contexto.Clientes.Find(id);
        }

        public List<Cliente> BuscarTodos()
        {
            return _contexto.Clientes.ToList();
        }

        public void Deletar(Cliente cliente)
        {
            var entry = _contexto.Entry(cliente);
            entry.State = System.Data.Entity.EntityState.Deleted;
            _contexto.SaveChanges();
        }
    }
}