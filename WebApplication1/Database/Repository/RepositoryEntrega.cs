using CoelhoRapido.Model.Database.Model;
using CoelhoRapido.Model.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace CoelhoRapido.Model.Database.Repository
{
    public class RepositoryEntrega : RepositoryBase<Entrega>
    {
        public RepositoryEntrega(ISession session) : base(session)
        {
        }
    }
}