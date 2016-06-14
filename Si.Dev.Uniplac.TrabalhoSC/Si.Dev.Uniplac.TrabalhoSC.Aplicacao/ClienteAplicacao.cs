using Si.Dev.Uniplac.TrabalhoSC.Dominio.Contratos;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //Verificar se Cliente já não existe


            //Salvar no Banco

            Cliente novoCliente = _clienteRepositorio.Adicionar(cliente);

            //Enviar e-mail de confirmação


            return novoCliente;

        }






        public void DeletarCliente(Cliente cliente)
        {
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
            Cliente clienteAtulizado = _clienteRepositorio.Atualizar(cliente);

            return clienteAtulizado;
        }
    }
}
