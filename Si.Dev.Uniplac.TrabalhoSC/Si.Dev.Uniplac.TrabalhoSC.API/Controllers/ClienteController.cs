﻿using Si.Dev.Uniplac.TrabalhoSC.Aplicacao;
using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using Si.Dev.Uniplac.TrabalhoSC.Infra.Dados.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Si.Dev.Uniplac.TrabalhoSC.API.Controllers
{
    [EnableCors(origins: "http://localhost:51870", headers: "*", methods: "*")]
    public class ClienteController : ApiController
    {
        static readonly IClienteAplicacao repository = new ClienteAplicacao(new ClienteRepositorio());

        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return repository.BuscarTodosCliente();
        }

        public HttpResponseMessage Post(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, cliente);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            if (id != cliente.Id)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                repository.AtualizarCliente(cliente);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete(Cliente _cliente)
        {
            Cliente cliente = repository.BuscarCliente(_cliente.Id);
            if (cliente == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                repository.DeletarCliente(cliente);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, cliente);
        }

        public Cliente Get(int id)
        {
            Cliente cliente = repository.BuscarCliente(id);
            if (cliente == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return cliente;
        }
    }
}
