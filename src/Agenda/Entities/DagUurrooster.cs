using System;
using System.Collections.Generic;

namespace Agendas.Entities
{
    public interface IDagUurrooster
    {
        IVak this[int uur] { get; set; }
    }

    public class DagUurrooster : IDagUurrooster
    {
        private readonly DayOfWeek dayOfWeek;
        private readonly IDictionary<int, IVak> uren = new Dictionary<int, IVak>();

        public DagUurrooster(DayOfWeek dayOfWeek)
        {
            this.dayOfWeek = dayOfWeek;
        }

        public IVak this[int uur]
        {
            get { return uren[uur]; }
            set { uren[uur] = value; }
        }
    }
}