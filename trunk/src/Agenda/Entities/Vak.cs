namespace Agendas.Entities
{
    public interface IVak
    {
    }

    public class Vak : IVak
    {
        private readonly string afkorting;
        private readonly string naam;

        public Vak(string afkorting, string naam)
        {
            this.afkorting = afkorting;
            this.naam = naam;
        }
    }
}