using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;

namespace CoelhoRapido.Model.Database.Model
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String User { get; set; }
        public String Password { get; set; }
        public IList<Endereco> Enderecos { get; set; }
    }

    public class ClienteMap : ClassMapping<Cliente>
    {
        public ClienteMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));
            Property(x => x.Name);
            Property(x => x.User);
            Property(x => x.Password);

            //Enderecos é um relacionamento n -> n um cliente pode ter n endereços e o mesmo endereço pode pertencer a n clientes
        }
    }
}