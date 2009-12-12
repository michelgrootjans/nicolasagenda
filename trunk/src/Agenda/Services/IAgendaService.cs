using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Agenda.Extensions;
using Agenda.ViewModels;

namespace Agenda.Services
{
    public interface IAgendaService
    {
        Dag GetContentFor(DateTime date);
        void Save(Dag dag);
    }

    public class AgendaService : IAgendaService
    {
        private const string AGENDA_DIR = "Agenda";
        private readonly XmlSerializer serializer;
        private readonly IScheduleService scheduleService;

        public AgendaService()
        {
            serializer = new XmlSerializer(typeof (Dag));
            scheduleService = new ScheduleService();
        }

        public void Save(Dag dag)
        {
            var fileName = GetFileName(dag.Date);
            if (File.Exists(fileName))
                File.Delete(fileName);
            using (var writer = new StreamWriter(fileName))
                serializer.Serialize(writer, dag);
        }

        public Dag GetContentFor(DateTime date)
        {
            var fileName = GetFileName(date);
            try
            {
                return GetContentFrom(fileName);
            }
            catch
            {
                return BlankFileFor(date);
            }
        }

        private Dag GetContentFrom(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (var reader = new StreamReader(fileName))
                {
                    var dag = serializer.Deserialize(reader) as Dag;
                    if (dag != null)
                    {
                        return dag;
                    }
                }
            }
            throw new FileNotFoundException(fileName);
        }

        private Dag BlankFileFor(DateTime date)
        {
            return new Dag(new List<Course>(), scheduleService.CoursesFor(date)){Date = date};
        }

        private static List<Course> ConvertTo(IEnumerable<Course> courses)
        {
            return courses.RemoveAll(c => c.Vak.IsNullOrEmpty() && c.Inhoud.IsNullOrEmpty())
                .ConvertAll(c => new Course(c.Vak, c.Inhoud))
                .ToList();
        }

        private static string GetFileName(DateTime date)
        {
            if (!Directory.Exists(AGENDA_DIR))
                Directory.CreateDirectory(AGENDA_DIR);
            return string.Format(AGENDA_DIR + "\\{0}", date.ToString("yyyy_MM_dd"));
        }
    }
}