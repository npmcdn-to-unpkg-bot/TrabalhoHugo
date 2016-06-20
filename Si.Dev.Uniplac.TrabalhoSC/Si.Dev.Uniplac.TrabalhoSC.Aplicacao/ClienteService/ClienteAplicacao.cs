using Si.Dev.Uniplac.TrabalhoSC.Dominio.Contratos;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using System.Collections.Generic;

namespace Si.Dev.Uniplac.TrabalhoSC.Aplicacao
{
    public class ClienteAplicacao : IClienteAplicacao
    {
        private IClienteRepositorio _clienteRepositorio;

        public ClienteAplicacao(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public Cliente CriarCliente(Cliente cliente)
        {
            return _clienteRepositorio.Adicionar(cliente);
        }

        public void DeletarCliente(Cliente cliente)
        {
            if (cliente != null)
                _clienteRepositorio.Deletar(cliente);
        }

        public Cliente BuscarCliente(int id)
        {
            return _clienteRepositorio.Buscar(id);
        }

        public List<Cliente> BuscarTodosCliente()
        {
            return _clienteRepositorio.BuscarTodos();
        }

        public Cliente AtualizarCliente(Cliente cliente)
        {
            return _clienteRepositorio.Atualizar(cliente);
        }
    }
}