using System;
using System.Collections.Generic;
using Agenda.Presentation;

namespace Agenda.Service
{
    public interface IAgendaService
    {
        IList<ICourse> GetContentFor(DateTime date);
        void Save(IList<ICourse> courses, DateTime date);
    }

    internal class AgendaService : IAgendaService
    {
        public IList<ICourse> GetContentFor(DateTime date)
        {
            IList<ICourse> dayContent = new List<ICourse>
                                            {
                                                new Course(1, "", ""),
                                                new Course(2, "", ""),
                                                new Course(3, "", ""),
                                                new Course(4, "", ""),
                                                new Course(5, "", ""),
                                                new Course(6, "", ""),
                                                new Course(7, "", "")
                                            };
            return dayContent;
        }

        public void Save(IList<ICourse> courses, DateTime date)
        {
        }
    }
}