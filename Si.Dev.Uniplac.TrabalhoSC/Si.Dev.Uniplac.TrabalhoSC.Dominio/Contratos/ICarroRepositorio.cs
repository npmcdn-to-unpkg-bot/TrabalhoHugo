using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Si.Dev.Uniplac.TrabalhoSC.Dominio.Contratos
{
    public interface ICarroRepositorio
    {
        Carro Adicionar(Carro carro);

        Carro Buscar(int id);

        List<Carro> BuscarTodos();

        Carro Atualizar(Carro carro);

        void Deletar(Carro carro);
    }
}
