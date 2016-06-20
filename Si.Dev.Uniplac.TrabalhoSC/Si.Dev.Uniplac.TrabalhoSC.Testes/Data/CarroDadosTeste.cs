using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Contexto;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Contratos;
using System.Data.Entity;
using Si.Dev.Uniplac.TrabalhoSC.Testes.Base;
using Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Repositorios;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using System.Collections.Generic;

namespace Si.Dev.Uniplac.TrabalhoSC.Testes.Data
{
    [TestClass]
    public class CarroDadosTeste
    {
        private ClienteContext _contexto;
        private ICarroRepositorio _repositorio;

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new CriarNovoBancoCarro<ClienteContext>());

            _contexto = new ClienteContext();
            _repositorio = new CarroRepositorio();

            _contexto.Database.Initialize(true);

            _contexto.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        [TestCleanup]
        public void Clear()
        {
        }

        [TestMethod]
        public void CriarCarroRepositorioTeste()
        {
            //Arrange - Cria objeto para persistir no banco
            Carro carro = new Carro("LZR4646", 1999, "Jeep");

            //Action - Salva no Banco
            _repositorio.Adicionar(carro);

            //Busca no Banco
            Carro novoCarro = _contexto.Carros.Find(carro.Id);

            // Assert
            Assert.IsTrue(novoCarro.Id > 0);
        }

        [TestMethod]
        public void RetornarCarrosRepositorioTest()
        {
            // Action - Busca no Banco
            Carro Carro = _repositorio.Buscar(1);

            // Assert
            Assert.IsNotNull(Carro);
        }

        [TestMethod]
        public void RetornaTodosOsCarrosRepositorioTeste()
        {
            // Action - Busca no banco
            List<Carro> carros = _repositorio.BuscarTodos();

            Assert.AreEqual(5, carros.Count);
        }

        [TestMethod]
        public void AtualizaCarroRepositorioTeste()
        {
            // Arrange - Busca no Banco
            Carro carro = _contexto.Carros.Find(1);

            carro.Placa = "LZ674646";
            carro.Ano = 2015;

            //Action
            _repositorio.Atualizar(carro);

            //Assert
            Carro carroAtualizado = _contexto.Carros.Find(1);
            Assert.AreEqual("LZ674646", carroAtualizado.Placa);
            Assert.AreEqual(2015, carroAtualizado.Ano);
        }

        [TestMethod]
        public void DeletarCarroRepositorioTeste()
        {
            //Arrange
            Carro carro = _contexto.Carros.Find(1);

            //Action
            _repositorio.Deletar(carro);

            _contexto.Entry(carro).Reload();

            //Assert
            Carro carroDeletado = _contexto.Carros.Find(1);
            Assert.IsNull(carroDeletado);
        }
    }
}
