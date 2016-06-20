using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Contexto;
using System.Data.Entity;

namespace Si.Dev.Uniplac.TrabalhoSC.Testes.Base
{
    public class CriarNovoBancoCarro<T> : DropCreateDatabaseAlways<ClienteContext>
    {
        protected override void Seed(ClienteContext context)
        {
            for (int i = 0; i < 5; i++)
            {
                //Criar cliente
                Carro carro = new Carro("123ABC" + i, 201 + i, "Palio");

                //Adicionar no contexto
                context.Carros.Add(carro);
            }

            //Salvar no contexto
            context.SaveChanges();

            base.Seed(context);
        }
    }
}