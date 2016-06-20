using Microsoft.VisualStudio.TestTools.UnitTesting;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;

namespace Si.Dev.Uniplac.TrabalhoSC.Testes.Dominio
{
    [TestClass]
    public class ServicoTeste
    {
        [TestMethod]
        public void Deveria_Criar_Servico()
        {
            Servico servico = new Servico(new Cliente("Bastião", 99520611, new Carro("LZR4646", 1999, "Jeep")), TipoServico.Revisao);

            Assert.AreEqual(servico.Cliente.Nome, "Bastião");
            Assert.AreEqual(servico.TipoServico, TipoServico.Revisao);
        }
    }
}