using Agendas.Entities;
using FluentNHibernate.Mapping;

namespace Agendas.FluentMappings
{
    public class DayMap : ClassMap<Day>
    {
        public DayMap()
        {
            Id(d => d.Id);
            Map(d => d.Date);
        }
    }
}