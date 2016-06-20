using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using System.Collections.Generic;

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