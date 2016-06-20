using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Contratos;

namespace Si.Dev.Uniplac.TrabalhoSC.Aplicacao
{
    public class CarroAplicacao : ICarroAplicacao
    {
        private ICarroRepositorio _carroRepositorio;

        public CarroAplicacao(ICarroRepositorio carroRepositorio)
        {
            _carroRepositorio = carroRepositorio;
        }

        public Carro AtualizarCarro(Carro carro)
        {
            return _carroRepositorio.Atualizar(carro);
        }

        public Carro BuscarCarro(int id)
        {
            return _carroRepositorio.Buscar(id);
        }

        public List<Carro> BuscarTodosCarro()
        {
            return _carroRepositorio.BuscarTodos();
        }

        public Carro CriarCarro(Carro carro)
        {
            return _carroRepositorio.Adicionar(carro);
        }

        public void DeletarCarro(Carro carro)
        {
            if (carro != null)
                _carroRepositorio.Deletar(carro);
        }
    }
}
