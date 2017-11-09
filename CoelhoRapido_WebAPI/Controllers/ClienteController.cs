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
    
    public class ClienteController : ApiController
    {
        // GET: api/Cliente
        public IEnumerable<Cliente> Get()
        {
            var list = DBConfig.Instance.RepositoryCliente.FindAll();
            return list;
        }

        // GET: api/Cliente/5
        public Cliente Get(Guid id)
        {
            return DBConfig.Instance.RepositoryCliente.FindById(id);
        }

        // POST: api/Cliente
        public void Post()
        {
            var c = new Cliente()
            {
                Name = "Zezim",
                Password = "!@#!@#",
                User = "Ze"
            };
            DBConfig.Instance.RepositoryCliente.Salvar(c);
        }

        // PUT: api/Cliente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cliente/5
        public void Delete(Guid id)
        {
            Cliente c = DBConfig.Instance.RepositoryCliente.FindById(id);
            DBConfig.Instance.RepositoryCliente.Deletar(c);
        }
    }
}
