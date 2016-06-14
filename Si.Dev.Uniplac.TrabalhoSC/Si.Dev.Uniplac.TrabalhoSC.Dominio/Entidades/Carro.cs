using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades
{
    public class Carro
    {
        public string Placa { get; set; }

        public int Ano { get; set; }

        public string Modelo { get; set; }

        public Carro(string placa, int ano, string modelo)
        {
            this.Placa = placa;
            this.Ano = ano;
            this.Modelo = modelo;
        }
    }
}
