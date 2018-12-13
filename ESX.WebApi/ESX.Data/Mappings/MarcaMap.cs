using ESX.Domain.Entities;
using FluentNHibernate.Mapping;

namespace ESX.Data.Mappings
{
    public class MarcaMap : ClassMap<Marca>
    {
        public MarcaMap()
        {
            Table("Marca");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Nome).Not.Nullable();
            HasMany<Patrimonio>(x => x.Patrimonios).KeyColumn("IdMarca");
        }
    }
}
