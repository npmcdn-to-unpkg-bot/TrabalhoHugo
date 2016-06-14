using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Si.Dev.Uniplac.TrabalhoSC.Dominio.Contratos
{
    public interface IClienteRepositorio
    {
        Cliente Adicionar(Cliente cliente);

        Cliente Buscar(int id);

        List<Cliente> BuscarTodos();

        Cliente Atualizar(Cliente cliente);

        void Deletar(Cliente cliente);
    }
}
