using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Contexto;
using System.Data.Entity;

namespace Si.Dev.Uniplac.TrabalhoSC.Testes.Base
{
    public class CriarNovoBancoCliente<T> : DropCreateDatabaseAlways<ClienteContext>
    {
        protected override void Seed(ClienteContext context)
        {
            for (int i = 0; i < 5; i++)
            {
                //Criar cliente
                Cliente cliente = new Cliente("Cliente " + i, 99520611 + i, new Carro("LZR464" + i, 1999 + i, "Jeep"));

                //Adicionar no contexto
                context.Clientes.Add(cliente);
            }

            //Salvar no contexto
            context.SaveChanges();

            base.Seed(context);
        }
    }
}