using Agenda.Presentation;

namespace Agenda.Service
{
    public class Course : ICourse
    {
        public int Uur { get; set; }
        public string Vak { get; set; }
        public string Inhoud { get; set; }

        public Course()
        {
        }

        public Course(ICourse course)
        {
            Uur = course.Uur;
            Vak = course.Vak;
            Inhoud = course.Inhoud;
        }

        public Course(int uur, string vak, string inhoud)
        {
            Uur = uur;
            Vak = vak;
            Inhoud = inhoud;
        }
    }
}