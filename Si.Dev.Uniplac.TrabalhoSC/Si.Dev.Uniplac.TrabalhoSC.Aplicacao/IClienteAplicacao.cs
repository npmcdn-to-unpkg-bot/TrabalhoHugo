using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Si.Dev.Uniplac.TrabalhoSC.Aplicacao
{
    public interface IClienteAplicacao
    {
        Cliente CriarCliente(Cliente cliente);
        void DeletarCliente(Cliente cliente);
        Cliente BuscarCliente(int id);
        List<Cliente> BuscarTodasCliente();
        Cliente AtualizarCliente(Cliente cliente);
    }
}
