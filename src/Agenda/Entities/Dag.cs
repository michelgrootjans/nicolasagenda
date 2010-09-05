using System;
using FluentNHibernate.Data;

namespace Agendas.Entities
{
    public interface IDag
    {
        DateTime Date { get; }
    }

    public class Dag : Entity, IDag
    {
        protected Dag()
        {
        }

        public Dag(DateTime date) : this()
        {
            Date = date;
        }

        public virtual DateTime Date { get; private set; }
    }
}