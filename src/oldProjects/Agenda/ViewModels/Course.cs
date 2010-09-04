using System;

namespace Agenda.ViewModels
{
    [Serializable]
    public class Course
    {
        public string Vak { get; set; }
        public string Inhoud { get; set; }

        public Course()
        {
        }

        public Course(string vak, string inhoud)
        {
            Vak = vak;
            Inhoud = inhoud;
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}", Vak, Inhoud);
        }
    }
}