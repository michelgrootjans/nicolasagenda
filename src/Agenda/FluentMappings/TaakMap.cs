using Agendas.Entities;
using FluentNHibernate.Mapping;

namespace Agendas.FluentMappings
{
    public class TaakMap : ClassMap<Taak>
    {
        public TaakMap()
        {
            Id(d => d.Id);
            Map(d => d.Vak);
            Map(d => d.Inhoud);
            Map(d => d.IsAf);
        }
    }
}