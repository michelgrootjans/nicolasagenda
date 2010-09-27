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
        int DayOfWeek { get; }
        IEnumerable<Taak> Taken { get; }
        ILesUur this[int lesuur] { get; }
        void AddTaak(string vak, string inhoud);
    }

    public class Dag : Entity, IDag
    {
        public virtual DateTime Date { get; private set; }
        private ISet<LesUur> vakken;
        private ISet<Taak> taken;

        protected Dag()
        {
        }

        public Dag(DateTime date) : this()
        {
            Date = date.Date;
            vakken = new HashedSet<LesUur>();
            taken = new HashedSet<Taak>();
        }

        public virtual IEnumerable<LesUur> Vakken
        {
            get { return vakken; }
        }

        public virtual IEnumerable<Taak> Taken
        {
            get { return taken; }
        }

        public virtual int DayOfWeek
        {
            get { return ((int) Date.DayOfWeek) - 1; }
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

        public virtual void AddTaak(string vak, string taak)
        {
            taken.Add(new Taak(vak, taak));
        }
    }

    public class Taak : Entity
    {
        public virtual string Vak { get; private set; }
        public virtual string Inhoud { get; private set; }

        protected Taak() {}

        public Taak(string vak, string taak)
        {
            Vak = vak;
            Inhoud = taak;
        }
    }
}