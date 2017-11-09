using CoelhoRapido.Model.Database.Model.Enum;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoelhoRapido.Model.Database.Model
{
    public class Endereco
    {
        public virtual Guid Id { get; set; }
        public virtual String Logradouro { get; set; }
        public virtual String Numero { get; set; }
        public virtual String Complemento { get; set; }
        public virtual String CEP { get; set; }
        public virtual String Bairro { get; set; }
        public virtual String Cidade { get; set; }
        public virtual String Estado { get; set; }
        public virtual TipoEnderecoEnum Tipo { get; set; }
        public virtual Boolean Preferencial { get; set; }
        public virtual Cliente Cliente { get; set; }
    }

    public class EnderecoMap : ClassMapping<Endereco>
    {
        public EnderecoMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));
            Property(x => x.Logradouro);
            Property(x => x.Numero);
            Property(x => x.Complemento);
            Property(x => x.CEP);
            Property(x => x.Bairro);
            Property(x => x.Cidade);
            Property(x => x.Estado);
            //Tipo é um Enum, não sei se está mapeado corretamente
            Property(x => x.Tipo);
            //Preferencial é um booleano (não sei se está mapeado corretamente)
            Property(x => x.Preferencial);

            ManyToOne(x => x.Cliente, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column("idCliente");
            });

        }
    }
}