using CoelhoRapido.Model.Database;
using CoelhoRapido.Model.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace CoelhoRapido_WebAPI.Controllers
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        private static List<Cliente> listaClientes = new List<Cliente>();

        [AcceptVerbs("POST")]
        [Route("CadastrarCliente")]
        public IList<Cliente> CadastrarCliente(Cliente cliente)
        {
            var list = DBConfig.Instance.RepositoryCliente.FindAll();
            return list;
        }

    }
}
