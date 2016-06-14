using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades
{
    public class Cliente
    {
        public string Nome { get; set; }

        public int Telefone { get; set; }

        public Carro Carro { get; set; }

        public Cliente(string nome, int telefone, Carro carro)
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.Carro = carro;
        }
    }
}
