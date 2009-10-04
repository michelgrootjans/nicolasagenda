using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Agenda.Presentation;

namespace Agenda.Service
{
    public interface IAgendaService
    {
        IList<ICourse> GetContentFor(DateTime date);
        void Save(IList<ICourse> courses, DateTime date);
    }

    public class AgendaService : IAgendaService
    {
        private const string AGENDA_DIR = "Agenda";
        private readonly XmlSerializer serializer;

        public AgendaService()
        {
            serializer = new XmlSerializer(typeof (List<Course>));
        }

        public void Save(IList<ICourse> courses, DateTime date)
        {
            var fileName = GetFileName(date);
            if (File.Exists(fileName))
                File.Delete(fileName);
            using (var writer = new StreamWriter(fileName))
                serializer.Serialize(writer, ConvertTo(courses));
        }

        public IList<ICourse> GetContentFor(DateTime date)
        {
            var fileName = GetFileName(date);
            try
            {
                return GetFile(fileName);
            }
            catch
            {
                return BlankFile();
            }
        }

        private IList<ICourse> GetFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (var reader = new StreamReader(fileName))
                {
                    var courses = serializer.Deserialize(reader) as List<Course>;
                    if (courses != null)
                    {
                        return courses.ConvertAll<ICourse>(c => c);
                    }
                }
            }
            return BlankFile();
        }

        private static IList<ICourse> BlankFile()
        {
            return new List<ICourse>
                       {
                           new Course(0, "", ""),
                           new Course(1, "", ""),
                           new Course(2, "", ""),
                           new Course(3, "", ""),
                           new Course(4, "", ""),
                           new Course(5, "", ""),
                           new Course(6, "", "")
                       };
        }

        private static List<Course> ConvertTo(IEnumerable<ICourse> courses)
        {
            return new List<ICourse>(courses).ConvertAll(c => new Course(c.Uur, c.Vak, c.Inhoud));
        }

        private static string GetFileName(DateTime date)
        {
            if (!Directory.Exists(AGENDA_DIR))
                Directory.CreateDirectory(AGENDA_DIR);
            return string.Format(AGENDA_DIR + "\\{0}", date.ToString("yyyy_MM_dd"));
        }
    }
}