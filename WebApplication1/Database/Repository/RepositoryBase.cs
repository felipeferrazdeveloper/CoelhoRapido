using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoelhoRapido.Model.Database.Repository
{
    public abstract class RepositoryBase<T> where T : class
    {
        public ISession Session = null;

        public RepositoryBase(ISession session)
        {
            this.Session = session;
        }

        public T FirstOrDefault()
        {
            return this.Session.Query<T>().FirstOrDefault();
        }

        public IList<T> FindAll()
        {
            return Session.CreateCriteria<T>().List<T>();
        }

        public virtual T Salvar(T model)
        {
            try
            {
                this.Session.Clear();

                var transaction = this.Session.BeginTransaction();

                this.Session.SaveOrUpdate(model);

                transaction.Commit();

                return model;
            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possível salvar.", ex);
            }
        }

        public virtual void Deletar(T model)
        {
            try
            {
                this.Session.Clear();

                var transaction = this.Session.BeginTransaction();

                this.Session.Delete(model);

                transaction.Commit();
            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possível deletar.", ex);
            }
        }

        public T FindFirstById(Guid id)
        {
            return this.Session.CreateCriteria<T>().Add(Restrictions.Eq("Id", id)).SetMaxResults(1).List<T>().FirstOrDefault();
        }

        public T FindById(Guid id)
        {
            return this.Session.Get<T>(id);
        }
    }
}