using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Si.Dev.Uniplac.TrabalhoSC.Dominio.Contratos
{
    public interface IServicoRepositorio
    {
        Servico Adicionar(Servico servico);

        Servico Buscar(int id);

        List<Servico> BuscarTodos();

        Servico Atualizar(Servico servico);

        void Deletar(Servico servico);
    }
}
