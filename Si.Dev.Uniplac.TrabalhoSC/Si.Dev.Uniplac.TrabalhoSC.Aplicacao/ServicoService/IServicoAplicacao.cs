using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Si.Dev.Uniplac.TrabalhoSC.Aplicacao.ServicoService
{
    public interface IServicoAplicacao
    {
        Servico CriarServico(Servico servico);

        void DeletarServico(Servico servico);

        Servico BuscarServico(int id);

        List<Servico> BuscarTodosServico();

        Servico AtualizarServico(Servico servico);
    }
}
