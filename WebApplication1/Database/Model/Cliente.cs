using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;

namespace CoelhoRapido.Model.Database.Model
{
    public class Cliente
    {
        public virtual Guid Id { get; set; }
        public virtual String Name { get; set; }
        public virtual String User { get; set; }
        public virtual String Password { get; set; }
        public virtual IList<Endereco> Enderecos { get; set; }
    }

    public class ClienteMap : ClassMapping<Cliente>
    {
        public ClienteMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));
            Property(x => x.Name);
            Property(x => x.User);
            Property(x => x.Password);

            Bag<Endereco>(x => x.Enderecos, m =>
            {
                m.Cascade(Cascade.All);
                m.Key(k => k.Column("idCliente"));
                m.Lazy(CollectionLazy.NoLazy);
                m.Inverse(true);
            },
            r => r.OneToMany());
        }
    }
}