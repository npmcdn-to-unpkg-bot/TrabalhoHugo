using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Contexto;
using System.Data.Entity;
using Si.Dev.Uniplac.TrabalhoSC.Testes.Base;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Contratos;
using Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Repositorios;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using System.Linq;
using System.Collections.Generic;

namespace Si.Dev.Uniplac.TrabalhoSC.Testes.Data
{
    [TestClass]
    public class ServicoDadosTeste
    {
        private ClienteContext _contexto;
        private IServicoRepositorio _repositorio;

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new CriarNovoBancoServico<ClienteContext>());

            _contexto = new ClienteContext();
            _repositorio = new ServicoRepositorio();

            _contexto.Database.Initialize(true);

            _contexto.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        [TestCleanup]
        public void Clear()
        {
        }

        [TestMethod]
        public void CriarServicoRepositorioTeste()
        {
            //Arrange - Cria objeto para persistir no banco
            Servico servico = new Servico(new Cliente("Bastião", 99520611, new Carro("LZR464", 1999, "Jeep")), TipoServico.Revisao);

            //Action - Salva no Banco
            _repositorio.Adicionar(servico);

            //Busca no Banco
            Servico novoCarro = _contexto.Servicos.Include(c => c.Cliente).Where(c => c.Id == servico.Cliente.Id).FirstOrDefault();

            // Assert
            Assert.IsTrue(novoCarro.Id > 0);
        }

        [TestMethod]
        public void RetornarServicosRepositorioTest()
        {
            // Action - Busca no Banco
            Servico servico = _repositorio.Buscar(1);

            // Assert
            Assert.IsNotNull(servico);
        }

        [TestMethod]
        public void RetornaTodosOsServicosRepositorioTeste()
        {
            // Action - Busca no banco
            List<Servico> servicos = _repositorio.BuscarTodos();

            Assert.AreEqual(5, servicos.Count);
        }

        [TestMethod]
        public void AtualizaServicoRepositorioTeste()
        {
            // Arrange - Busca no Banco
            Servico servico = _contexto.Servicos.Find(1);
            servico.Cliente = new Cliente("José", 99520611, new Carro("LZR464", 1999, "UNO"));
            servico.TipoServico = TipoServico.TrocaDeFluidoFreio;

            //Action
            _repositorio.Atualizar(servico);

            //Assert
            Servico servicoAtualizado = _contexto.Servicos.Find(1);
            Assert.AreEqual("José", servicoAtualizado.Cliente.Nome);
            Assert.AreEqual(TipoServico.TrocaDeFluidoFreio, servicoAtualizado.TipoServico);
        }

        [TestMethod]
        public void DeletarServicoRepositorioTeste()
        {
            //Arrange
            Servico servico = _contexto.Servicos.Find(1);

            //Action
            _repositorio.Deletar(servico);

            _contexto.Entry(servico).Reload();

            //Assert
            Servico servicoDeletado = _contexto.Servicos.Find(1);
            Assert.IsNull(servicoDeletado);
        }
    }
}
