namespace Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Telefone { get; set; }

        public Carro Carro { get; set; }

        public Cliente()
        {
        }

        public Cliente(string nome, int telefone, Carro carro)
        {
            Nome = nome;
            Telefone = telefone;
            Carro = carro;
        }
    }
}