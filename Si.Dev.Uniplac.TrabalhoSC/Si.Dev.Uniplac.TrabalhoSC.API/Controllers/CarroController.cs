using Si.Dev.Uniplac.TrabalhoSC.Aplicacao;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Repositorios;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Si.Dev.Uniplac.TrabalhoSC.API.Controllers
{
    public class CarroController : ApiController
    {
        private static readonly ICarroAplicacao repository = new CarroAplicacao(new CarroRepositorio());

        [HttpGet]
        public IEnumerable<Carro> Get()
        {
            return repository.BuscarTodosCarro();
        }

        public HttpResponseMessage Post(Carro carro)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, carro);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(int id, Carro carro)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            if (id != carro.Id)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                repository.AtualizarCarro(carro);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete(int id)
        {
            Carro carro = repository.BuscarCarro(id);
            if (carro == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                repository.DeletarCarro(carro);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, carro);
        }

        public Carro Get(int id)
        {
            Carro carro = repository.BuscarCarro(id);
            if (carro == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return carro;
        }
    }
}