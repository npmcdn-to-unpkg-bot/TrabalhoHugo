using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades
{
    public class Servico
    {
        public int Identificacao { get; set; }
        public Cliente Cliente { get; set; }

        public TipoServico TipoServico { get; set; }

        public Servico(Cliente cliente, TipoServico tipoServico)
        {
            this.Identificacao = Identificacao;
            this.Cliente = cliente;
            this.TipoServico = tipoServico;
        }
    }
}
