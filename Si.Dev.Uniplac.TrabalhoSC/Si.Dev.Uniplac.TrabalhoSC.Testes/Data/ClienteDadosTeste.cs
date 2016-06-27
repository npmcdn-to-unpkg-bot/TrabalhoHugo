using Microsoft.VisualStudio.TestTools.UnitTesting;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Contratos;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Contexto;
using Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Repositorios;
using Si.Dev.Uniplac.TrabalhoSC.Testes.Base;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Si.Dev.Uniplac.TrabalhoSC.Testes.Data
{
    [TestClass]
    public class ClienteDadosTeste
    {
        private ClienteContext _contexto;
        private IClienteRepositorio _repositorio;

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new CriarNovoBancoCliente<ClienteContext>());

            _contexto = new ClienteContext();
            _repositorio = new ClienteRepositorio();

            _contexto.Database.Initialize(true);

            _contexto.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        [TestCleanup]
        public void Clear()
        {
        }

        [TestMethod]
        public void CriarClienteRepositorioTeste()
        {
            //Arrange - Cria objeto para persistir no banco
            Cliente cliente = new Cliente("Bastião", 99520611, new Carro("LZR4646", 1999, "Jeep"));

            //Action - Salva no Banco
            _repositorio.Adicionar(cliente);

            //Busca no Banco
            Cliente novoCliente = _contexto.Clientes.Include(c => c.Carro).Where(c => c.Id == cliente.Carro.Id).FirstOrDefault();

            // Assert
            Assert.IsTrue(novoCliente.Id > 0);
            Assert.AreEqual(cliente.Telefone, novoCliente.Telefone);
            Assert.AreEqual(cliente.Carro.Placa, novoCliente.Carro.Placa);
        }

        [TestMethod]
        public void RetornarClientesRepositorioTest()
        {
            // Action - Busca no Banco
            Cliente cliente = _repositorio.Buscar(1);

            // Assert
            Assert.IsNotNull(cliente);
        }

        [TestMethod]
        public void RetornaTodosOsClientesRepositorioTeste()
        {
            // Action - Busca no banco
            List<Cliente> clientes = _repositorio.BuscarTodos();

            Assert.AreEqual(5, clientes.Count);
        }

        [TestMethod]
        public void AtualizaClienteRepositorioTeste()
        {
            // Arrange - Busca no Banco
            Cliente cliente = _contexto.Clientes.Include(c => c.Carro).FirstOrDefault(i => i.Id == 1);;

            cliente.Nome = "Bastião";
            cliente.Telefone = 99999999;

            //Action
            _repositorio.Atualizar(cliente);

            //Assert
            Cliente clienteAtualizado = _contexto.Clientes.Find(1);
            Assert.AreEqual("Bastião", clienteAtualizado.Nome);
            Assert.AreEqual(99999999, clienteAtualizado.Telefone);
        }

        [TestMethod]
        public void DeletarClienteRepositorioTeste()
        {
            //Arrange
            Cliente cliente = _contexto.Clientes.Find(1);

            //Action
            _repositorio.Deletar(cliente);

            _contexto.Entry(cliente).Reload();

            //Assert
            Cliente clienteDeletado = _contexto.Clientes.Find(1);
            Assert.IsNull(clienteDeletado);
        }
    }
}