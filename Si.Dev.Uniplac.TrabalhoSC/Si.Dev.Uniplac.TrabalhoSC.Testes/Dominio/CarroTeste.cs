using Microsoft.VisualStudio.TestTools.UnitTesting;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;

namespace Si.Dev.Uniplac.TrabalhoSC.Testes.Dominio
{
    [TestClass]
    public class CarroTeste
    {
        [TestMethod]
        public void Deveria_Criar_Carro()
        {
            Carro carro = new Carro("LZR4646", 1999, "Jeep");
            Assert.AreEqual(1999, carro.Ano);
            Assert.AreEqual("Jeep", carro.Modelo);
            Assert.AreEqual("LZR4646", carro.Placa);
        }
    }
}