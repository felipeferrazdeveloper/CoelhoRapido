using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;

namespace CoelhoRapido.Model.Database.Model
{
    public class Entrega
    {
        public Guid Id { get; set; }
        public Endereco Origem { get; set; }
        public Endereco Destino { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataPrazo { get; set; }
        public IList<Volume> Volumes { get; set; }
        public String Registro
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
            Property(x => x.Origem);
            Property(x => x.Destino);
            Property(x => x.DataRetirada);
            Property(x => x.DataEntrega);
            Property(x => x.DataPrazo);
            Property(x => x.Registro);

            //Volumes relacionmento n -> 1 ( uma entrega tem N volumes, porém um volume só pertence à uma única entrega
        }
    }
}