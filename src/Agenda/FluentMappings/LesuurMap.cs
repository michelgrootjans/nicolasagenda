using Agendas.Entities;
using FluentNHibernate.Mapping;

namespace Agendas.FluentMappings
{
    public class LesuurMap : ClassMap<LesUur>
    {
        public LesuurMap()
        {
            Id(u => u.Id);
            Map(u => u.Uur);
            Map(u => u.Naam);
            Map(u => u.Inhoud);
        }
    }

}