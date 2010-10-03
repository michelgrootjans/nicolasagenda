using System.Windows.Forms;
using FluentNHibernate.Data;

namespace Agendas.Entities
{
    public interface ITaak
    {
        string Beschrijving { get; }
        bool IsAf { get; }
    }

    public class Taak : Entity, ITaak
    {
        public virtual string Vak { get; private set; }
        public virtual string Inhoud { get; private set; }
        public virtual bool IsAf { get; private set; }

        protected Taak() {}

        public Taak(string vak, string taak)
        {
            Vak = vak;
            Inhoud = taak;
        }

        public virtual string Beschrijving
        {
            get { return string.Format("{0}: {1}", Vak, Inhoud); }
        }

        public virtual bool Equals(Taak other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Vak, Vak) && Equals(other.Inhoud, Inhoud);
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other as Taak);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Vak != null
                                             ? Vak.GetHashCode()
                                             : 0);
                result = (result*397) ^ (Inhoud != null
                                             ? Inhoud.GetHashCode()
                                             : 0);
                return result;
            }
        }
    }
}