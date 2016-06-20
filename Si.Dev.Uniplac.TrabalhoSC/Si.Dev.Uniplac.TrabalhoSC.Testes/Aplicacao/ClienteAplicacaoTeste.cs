using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Contratos;
using Si.Dev.Uniplac.TrabalhoSC.Aplicacao;

namespace Si.Dev.Uniplac.TrabalhoSC.Testes.Aplicacao
{
    [TestClass]
    public class ClienteAplicacaoTeste
    {
        [TestMethod]
        public void CriarClienteAplicacaoTeste()
        {
            //Monta objeto
            Cliente cliente = new Cliente("Bastião", 99520611, new Carro("LZR4646", 1999, "Jeep"));

            //MOCK
            var repositorioFake = new Mock<IClienteRepositorio>();
            repositorioFake.Setup(x => x.Adicionar(cliente)).Returns(new Cliente());

            IClienteAplicacao servico = new ClienteAplicacao(repositorioFake.Object);
            Cliente novoCliente = servico.CriarCliente(cliente);

            //VERIFICA SE FEZ A CHAMADA AO MÉTODO - CHAMOU: TESTE PASSA; NÃO CHAMOU: TESTE DÁ ERRO;   
            repositorioFake.Verify(x => x.Adicionar(cliente));
        }

        [TestMethod]
        public void RetornarClientesAplicacaoTest()
        {
            var repositorioFake = new Mock<IClienteRepositorio>();
            repositorioFake.Setup(x => x.Buscar(1)).Returns(new Cliente());

            // Action - Busca no Banco
            IClienteAplicacao servico = new ClienteAplicacao(repositorioFake.Object);
            Cliente cliente = servico.BuscarCliente(1);

            repositorioFake.Verify(x => x.Buscar(1));
        }

        [TestMethod]
        public void AtualizarClienteAplicacaoTeste()
        {
            Cliente cliente = new Cliente("Bastião", 99520611, new Carro("LZR4646", 1999, "Jeep"));

            var repositorioFake = new Mock<IClienteRepositorio>();
            IClienteAplicacao servico = new ClienteAplicacao(repositorioFake.Object);

            Cliente clienteAtualizado = servico.AtualizarCliente(cliente);

            repositorioFake.Verify(x => x.Atualizar(cliente));
        }

        [TestMethod]
        public void DeletarClienteAplicacaoTeste()
        {
            var repositorioFake = new Mock<IClienteRepositorio>();

            IClienteAplicacao servico = new ClienteAplicacao(repositorioFake.Object);

            Cliente cliente = new Cliente("Bastião", 99520611, new Carro("LZR4646", 1999, "Jeep"));

            servico.DeletarCliente(cliente);

            repositorioFake.Verify(x => x.Deletar(cliente));
        }
    }
}
