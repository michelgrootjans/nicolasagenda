using System;
using FluentNHibernate.Data;

namespace Agendas.Entities
{
    public interface IDay
    {
        DateTime Date { get; }
    }

    public class Day : Entity, IDay
    {
        protected Day()
        {
        }

        public Day(DateTime date) : this()
        {
            Date = date;
        }

        public virtual DateTime Date { get; private set; }
    }
}