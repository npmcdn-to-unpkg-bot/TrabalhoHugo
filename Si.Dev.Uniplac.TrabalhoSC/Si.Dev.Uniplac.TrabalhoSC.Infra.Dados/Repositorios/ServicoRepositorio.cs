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
    public class ServicoRepositorio : IServicoRepositorio
    {
        private ClienteContext _contexto;

        public ServicoRepositorio()
        {
            _contexto = new ClienteContext();
        }

        public Servico Adicionar(Servico Servico)
        {
            var resultado = _contexto.Servicos.Add(Servico);
            _contexto.SaveChanges();
            return resultado;
        }

        public Servico Atualizar(Servico Servico)
        {
            var entry = _contexto.Entry<Servico>(Servico);
            entry.State = System.Data.Entity.EntityState.Modified;
            _contexto.SaveChanges();

            return Servico;
        }

        public Servico Buscar(int id)
        {
            return _contexto.Servicos.Find(id);
        }

        public List<Servico> BuscarTodos()
        {
            return _contexto.Servicos.ToList();
        }

        public void Deletar(Servico Servico)
        {
            var entry = _contexto.Entry(Servico);
            entry.State = System.Data.Entity.EntityState.Deleted;
            _contexto.SaveChanges();
        }
    }
}
