using CoelhoRapido.Model.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace CoelhoRapido.Model.Database.Repository
{
    public class RepositoryEndereco : RepositoryBase<Endereco>
    {
        public RepositoryEndereco(ISession session) : base(session)
        {
        }
    }
}