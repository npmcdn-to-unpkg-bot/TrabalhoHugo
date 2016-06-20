using Si.Dev.Uniplac.TrabalhoSC.Aplicacao.ServicoService;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Contratos;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using System.Collections.Generic;
using System;

namespace Si.Dev.Uniplac.TrabalhoSC.Aplicacao
{
    public class ServicoAplicacao : IServicoAplicacao
    {
        private IServicoRepositorio _servicoRepositorio;

        public ServicoAplicacao(IServicoRepositorio ServicoRepositorio)
        {
            _servicoRepositorio = ServicoRepositorio;
        }

        public Servico CriarServico(Servico Servico)
        {
            return _servicoRepositorio.Adicionar(Servico);
        }

        public void DeletarServico(Servico Servico)
        {
            if (Servico != null)
                _servicoRepositorio.Deletar(Servico);
        }

        public Servico BuscarServico(int id)
        {
            return _servicoRepositorio.Buscar(id);
        }

        public List<Servico> BuscarTodosServico()
        {
            return _servicoRepositorio.BuscarTodos();
        }

        public Servico AtualizarServico(Servico Servico)
        {
            return _servicoRepositorio.Atualizar(Servico);
        }
    }
}