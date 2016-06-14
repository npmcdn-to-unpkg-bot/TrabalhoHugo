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

        public Cliente CriarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void DeletarCliente(Dominio.Entidades.Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Dominio.Entidades.Cliente BuscarCliente(int id)
        {
            throw new NotImplementedException();
        }

        public List<Dominio.Entidades.Cliente> BuscarTodasCliente()
        {
            throw new NotImplementedException();
        }

        public Dominio.Entidades.Cliente AtualizarCliente(Dominio.Entidades.Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
