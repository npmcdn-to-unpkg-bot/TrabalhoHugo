using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Si.Dev.Uniplac.TrabalhoSC.Aplicacao
{
    public interface ICarroAplicacao
    {
        Carro CriarCarro(Carro carro);

        void DeletarCarro(Carro carro);

        Carro BuscarCarro(int id);

        List<Carro> BuscarTodosCarro();

        Carro AtualizarCarro(Carro carro);
    }
}
