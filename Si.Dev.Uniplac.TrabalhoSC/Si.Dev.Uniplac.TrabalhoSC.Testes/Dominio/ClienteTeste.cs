using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;

namespace Si.Dev.Uniplac.TrabalhoSC.Testes.Dominio
{
    [TestClass]
    public class ClienteTeste
    {
        public ClienteTeste()
        {
           
        }

        [TestMethod]
        public void Deveria_Criar_Cliente()
        {
            Cliente cliente = new Cliente("Bastião", 99520611, new Carro("LZR4646",1999, "Jeep"));

            Assert.AreEqual("Bastião", cliente.Nome);
            Assert.AreEqual(99520611, cliente.Telefone);

            Carro carro = new Carro("LZR4646",1999, "Jeep");
            Assert.AreEqual(carro.Ano, cliente.Carro.Ano);
            Assert.AreEqual(carro.Modelo, cliente.Carro.Modelo);
            Assert.AreEqual(carro.Placa, cliente.Carro.Placa);
        }
       
    }
}
