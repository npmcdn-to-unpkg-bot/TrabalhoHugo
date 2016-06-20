namespace Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades
{
    public class Carro
    {
        public int Id { get; set; }

        public string Placa { get; set; }

        public int Ano { get; set; }

        public string Modelo { get; set; }

        public Carro() { }

        public Carro(string placa, int ano, string modelo)
        {
            Placa = placa;
            Ano = ano;
            Modelo = modelo;
        }
    }
}