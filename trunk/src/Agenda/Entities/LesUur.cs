using FluentNHibernate.Data;

namespace Agendas.Entities
{
    public interface ILesUur
    {
        int Uur { get; }
        string Naam { get; set; }
        string Inhoud { get; set; }
    }

    public class LesUur : Entity, ILesUur
    {
        protected LesUur()
        {
        }

        public LesUur(int uur)
        {
            Uur = uur;
        }

        public virtual int Uur { get; private set; }
        public virtual string Naam { get; set; }
        public virtual string Inhoud { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as LesUur);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ Uur;
                result = (result*397) ^ (Naam != null
                                             ? Naam.GetHashCode()
                                             : 0);
                return result;
            }
        }

        private bool Equals(LesUur other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Uur == Uur && Equals(other.Naam, Naam) && Equals(other.Id, Id);
        }
    }
}