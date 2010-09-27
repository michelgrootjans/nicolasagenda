using Agendas.Entities;
using FluentNHibernate.Mapping;

namespace Agendas.FluentMappings
{
    public class DayMap : ClassMap<Dag>
    {
        public DayMap()
        {
            Id(d => d.Id);
            Map(d => d.Date);
            HasMany(d => d.Vakken)
                .Access.LowerCaseField()
                .AsSet()
                .Cascade.AllDeleteOrphan();
            HasMany(d => d.Taken)
                .Access.LowerCaseField()
                .AsSet()
                .Cascade.AllDeleteOrphan();
        }
    }
}