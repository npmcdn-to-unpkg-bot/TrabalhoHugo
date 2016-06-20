namespace Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades
{
    public class Servico
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public TipoServico TipoServico { get; set; }

        public Servico() { }

        public Servico(Cliente cliente, TipoServico tipoServico)
        {
            Cliente = cliente;
            TipoServico = tipoServico;
        }
    }
}