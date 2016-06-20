using Si.Dev.Uniplac.TrabalhoSC.Dominio.Contratos;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Repositorios
{
    public class CarroRepositorio : ICarroRepositorio
    {
        private ClienteContext _contexto;

        public CarroRepositorio()
        {
            _contexto = new ClienteContext();
        }

        public Carro Adicionar(Carro Carro)
        {
            var resultado = _contexto.Carros.Add(Carro);
            _contexto.SaveChanges();
            return resultado;
        }

        public Carro Atualizar(Carro Carro)
        {
            var entry = _contexto.Entry<Carro>(Carro);
            entry.State = System.Data.Entity.EntityState.Modified;
            _contexto.SaveChanges();

            return Carro;
        }

        public Carro Buscar(int id)
        {
            return _contexto.Carros.Find(id);
        }

        public List<Carro> BuscarTodos()
        {
            return _contexto.Carros.ToList();
        }

        public void Deletar(Carro Carro)
        {
            var entry = _contexto.Entry(Carro);
            entry.State = System.Data.Entity.EntityState.Deleted;
            _contexto.SaveChanges();
        }
    }
}
