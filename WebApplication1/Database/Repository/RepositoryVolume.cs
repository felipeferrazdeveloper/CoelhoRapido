﻿using CoelhoRapido.Model.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace CoelhoRapido.Model.Database.Repository
{
    public class RepositoryVolume : RepositoryBase<Volume>
    {
        public RepositoryVolume(ISession session) : base(session)
        {
        }
    }
}