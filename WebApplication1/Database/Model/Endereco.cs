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
        public Guid Id { get; set; }
        public String Logradouro { get; set; }
        public String Numero { get; set; }
        public String Complemento { get; set; }
        public String CEP { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }
        public TipoEnderecoEnum Tipo { get; set; }
        public Boolean Preferencial { get; set; }
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

        }
    }
}