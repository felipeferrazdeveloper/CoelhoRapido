using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoelhoRapido.Model.Database.Model
{
    public class Volume
    {
        public Guid Id { get; set; }
        public String Descricao { get; set; }
        public Double ValorDeclarado { get; set; }
        public Double Peso { get; set; }
        public Double Altura { get; set; }
        public Double Largura { get; set; }
        public Double Profundidade { get; set; }
        
    }

    public class VolumeMap : ClassMapping<Volume>
    {
        public VolumeMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));
            Property(x => x.Descricao);
            Property(x => x.ValorDeclarado);
            Property(x => x.Peso);
            Property(x => x.Altura);
            Property(x => x.Largura);
            Property(x => x.Profundidade);
        }
    }
}