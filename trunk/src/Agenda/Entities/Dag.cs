using System;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Data;
using Iesi.Collections.Generic;

namespace Agendas.Entities
{
    public interface IDag
    {
        DateTime Date { get; }
        IEnumerable<LesUur> Vakken { get; }
        ILesUur this[int lesuur] { get; }
    }

    public class Dag : Entity, IDag
    {
        public virtual DateTime Date { get; private set; }
        private ISet<LesUur> vakken;

        protected Dag()
        {
        }

        public Dag(DateTime date) : this()
        {
            Date = date.Date;
            vakken = new HashedSet<LesUur>();
        }

        public virtual IEnumerable<LesUur> Vakken
        {
            get { return vakken; }
        }

        public virtual void AddVak(int lesuur, string vak, string lesInhoud)
        {
            vakken.Add(new LesUur(lesuur)
                           {
                               Naam = vak,
                               Inhoud = lesInhoud
                           });
        }

        public virtual ILesUur this[int lesuur]
        {
            get
            {
                var les = vakken.Where(v => v.Uur == lesuur).FirstOrDefault();
                return les;
            }
        }
    }
}