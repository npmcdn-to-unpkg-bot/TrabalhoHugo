using Si.Dev.Uniplac.TrabalhoSC.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Si.Dev.Uniplac.TrabalhoSC.API.Controllers
{
    public class ClienteController : ApiController
    {
        public ClienteController()
        {

        }

        public List<Cliente> GetAll()
        {
            return null;
            //return ClienteAplicacao.GetAll();
        }
    }        
}
