using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using System.Collections.Generic;

namespace Si.Dev.Uniplac.TrabalhoSC.Aplicacao
{
    public interface IClienteAplicacao
    {
        Cliente CriarCliente(Cliente cliente);

        void DeletarCliente(Cliente cliente);

        Cliente BuscarCliente(int id);

        List<Cliente> BuscarTodosCliente();

        Cliente AtualizarCliente(Cliente cliente);
    }
}