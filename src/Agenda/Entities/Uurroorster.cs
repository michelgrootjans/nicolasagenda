using System;

namespace Agendas.Entities
{
    public interface IUurroorster
    {
        IVak VakVoor(DateTime dateTime);
        IDagUurrooster Maandag { get; }
    }

    public class Uurrooster : IUurroorster
    {
        public IVak VakVoor(DateTime dateTime)
        {
            return null;
        }

        public IDagUurrooster Maandag
        {
            get { return new DagUurrooster(DayOfWeek.Monday); }
        }
    }
}