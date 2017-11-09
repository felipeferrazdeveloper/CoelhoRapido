using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;

namespace CoelhoRapido.Model.Database.Model
{
    public class Entrega
    {
        public virtual Guid Id { get; set; }
        public virtual Endereco Origem { get; set; }
        public virtual Endereco Destino { get; set; }
        public virtual DateTime DataRetirada { get; set; }
        public virtual DateTime DataEntrega { get; set; }
        public virtual DateTime DataPrazo { get; set; }
        public virtual IList<Volume> Volumes { get; set; }
        public virtual String Registro
        {
            get
            {
                return Registro;
            }
            set
            {
                
            }
        }

        public Entrega()
        {
            Registro = new Random().ToString();
        }

    }

    public class EntregaMap : ClassMapping<Entrega>
    {
        public EntregaMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));
            OneToOne(x => x.Origem, m =>
            {
                m.Cascade(Cascade.Persist);
                m.Constrained(true);
                m.Lazy(LazyRelation.Proxy); // or .NoProxy, .NoLazy
                m.PropertyReference(typeof(Endereco).GetPropertyOrFieldMatchingName("idEndereco"));
                m.OptimisticLock(true);
                m.Access(Accessor.Field);
            });
            OneToOne(x => x.Destino, m =>
            {
                m.Cascade(Cascade.Persist);
                m.Constrained(true);
                m.Lazy(LazyRelation.Proxy); // or .NoProxy, .NoLazy
                m.PropertyReference(typeof(Endereco).GetPropertyOrFieldMatchingName("idEndereco"));
                m.OptimisticLock(true);
                m.Access(Accessor.Field);
            });
            Property(x => x.DataRetirada);
            Property(x => x.DataEntrega);
            Property(x => x.DataPrazo);
            Property(x => x.Registro);

            Bag <Volume>(x => x.Volumes, m =>
            {
                m.Cascade(Cascade.All);
                m.Key(k => k.Column("idEntrega"));
                m.Lazy(CollectionLazy.NoLazy);
                m.Inverse(true);
            },
            r => r.OneToMany());
        }
    }
}