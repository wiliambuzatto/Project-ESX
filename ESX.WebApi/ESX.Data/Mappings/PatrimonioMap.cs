using ESX.Domain.Entities;
using FluentNHibernate.Mapping;

namespace ESX.Data.Mappings
{
    public class PatrimonioMap : ClassMap<Patrimonio>
    {
        public PatrimonioMap()
        {
            Table("Patrimonio");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Nome).Not.Nullable();
            Map(x => x.Descricao).Nullable();
            Map(x => x.NumeroTombo).Nullable();
            References(x => x.Marca).Column("IdMarca").Not.Nullable();
        }
    }
}
