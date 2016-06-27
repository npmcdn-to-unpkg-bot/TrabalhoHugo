using Si.Dev.Uniplac.TrabalhoSC.Dominio.Contratos;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Contexto;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Repositorios
{
    public class ServicoRepositorio : IServicoRepositorio
    {
        private ClienteContext _contexto;

        public ServicoRepositorio()
        {
            _contexto = new ClienteContext();
        }

        public Servico Adicionar(Servico servico)
        {
            var resultado = _contexto.Servicos.Add(servico);
            _contexto.SaveChanges();
            return resultado;
        }

        public Servico Atualizar(Servico servico)
        {
            var dbServico = _contexto.Servicos
                       .Include(x => x.Cliente)
                       .Include(x => x.Cliente.Carro)
                       .Single(c => c.Id == servico.Id);

            _contexto.Entry(dbServico).CurrentValues.SetValues(servico);
            _contexto.Entry(dbServico.Cliente).CurrentValues.SetValues(servico.Cliente);
            _contexto.Entry(dbServico.Cliente.Carro).CurrentValues.SetValues(servico.Cliente.Carro);

            _contexto.SaveChanges();

            return servico;
        }

        public Servico Buscar(int id)
        {
            return _contexto.Servicos.Include(c => c.Cliente).Include(c => c.Cliente.Carro).FirstOrDefault(i => i.Id == id);
        }

        public List<Servico> BuscarTodos()
        {
            return _contexto.Servicos
                .Include(c => c.Cliente)
                .Include(c => c.Cliente.Carro)
                .ToList();
        }

        public void Deletar(Servico servico)
        {
            var entry = _contexto.Entry(servico);
            entry.State = System.Data.Entity.EntityState.Deleted;
            _contexto.SaveChanges();
        }
    }
}
