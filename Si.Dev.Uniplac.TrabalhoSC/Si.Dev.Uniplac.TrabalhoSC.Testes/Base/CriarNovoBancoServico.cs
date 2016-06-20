using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Contexto;
using System.Data.Entity;

namespace Si.Dev.Uniplac.TrabalhoSC.Testes.Base
{
    public class CriarNovoBancoServico<T> : DropCreateDatabaseAlways<ClienteContext>
    {
        protected override void Seed(ClienteContext context)
        {
            for (int i = 0; i < 5; i++)
            {
                //Criar cliente
                Servico servico = new Servico(new Cliente("Cliente " + i, 99520611 + i, new Carro("LZR464" + i, 1999 + i, "Jeep")), TipoServico.Revisao);

                //Adicionar no contexto
                context.Servicos.Add(servico);
            }

            //Salvar no contexto
            context.SaveChanges();

            base.Seed(context);
        }
    }
}