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
        public virtual Guid Id { get; set; }
        public virtual String Descricao { get; set; }
        public virtual Double ValorDeclarado { get; set; }
        public virtual Double Peso { get; set; }
        public virtual Double Altura { get; set; }
        public virtual Double Largura { get; set; }
        public virtual Double Profundidade { get; set; }
        public virtual Entrega Entrega { get; set; }
        
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

            ManyToOne(x => x.Entrega, m =>
            {
                m.Column("idEntrega");
            });

        }
    }
}