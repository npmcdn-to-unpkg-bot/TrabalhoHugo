using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Contratos;
using Si.Dev.Uniplac.TrabalhoSC.Aplicacao.ServicoService;
using Moq;
using Si.Dev.Uniplac.TrabalhoSC.Aplicacao;

namespace Si.Dev.Uniplac.TrabalhoSC.Testes.Aplicacao
{
    [TestClass]
    public class ServicoAplicacaoTeste
    {
        [TestMethod]
        public void CriarServicoAplicacaoTeste()
        {
            //Monta objeto
            Servico objServico = new Servico(new Cliente("Bastião", 99520611, new Carro("LZR4646", 1999, "Jeep")), TipoServico.TrocaDeOleo);

            //MOCK
            var repositorioFake = new Mock<IServicoRepositorio>();
            repositorioFake.Setup(x => x.Adicionar(objServico)).Returns(new Servico());

            IServicoAplicacao servico = new ServicoAplicacao(repositorioFake.Object);
            Servico novoServico = servico.CriarServico(objServico);

            //VERIFICA SE FEZ A CHAMADA AO MÉTODO - CHAMOU: TESTE PASSA; NÃO CHAMOU: TESTE DÁ ERRO;   
            repositorioFake.Verify(x => x.Adicionar(objServico));
        }

        [TestMethod]
        public void RetornarServicosAplicacaoTest()
        {
            var repositorioFake = new Mock<IServicoRepositorio>();
            repositorioFake.Setup(x => x.Buscar(1)).Returns(new Servico());

            // Action - Busca no Banco
            IServicoAplicacao servico = new ServicoAplicacao(repositorioFake.Object);
            Servico Servico = servico.BuscarServico(1);

            repositorioFake.Verify(x => x.Buscar(1));
        }

        [TestMethod]
        public void AtualizarServicoAplicacaoTeste()
        {
            Servico objServico = new Servico(new Cliente("Bastião", 99520611, new Carro("LZR4646", 1999, "Jeep")), TipoServico.TrocaDeOleo);

            var repositorioFake = new Mock<IServicoRepositorio>();
            IServicoAplicacao servico = new ServicoAplicacao(repositorioFake.Object);

            Servico ServicoAtualizado = servico.AtualizarServico(objServico);

            repositorioFake.Verify(x => x.Atualizar(objServico));
        }

        [TestMethod]
        public void DeletarServicoAplicacaoTeste()
        {
            var repositorioFake = new Mock<IServicoRepositorio>();

            IServicoAplicacao servico = new ServicoAplicacao(repositorioFake.Object);

            Servico objServico = new Servico(new Cliente("Bastião", 99520611, new Carro("LZR4646", 1999, "Jeep")), TipoServico.TrocaDeOleo);

            servico.DeletarServico(objServico);

            repositorioFake.Verify(x => x.Deletar(objServico));
        }
    }
}
