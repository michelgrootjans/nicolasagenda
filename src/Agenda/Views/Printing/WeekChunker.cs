using System;
using System.Collections;
using System.Collections.Generic;
using Agendas.Entities;
using System.Linq;

namespace Agendas.Views.Printing
{
    internal class WeekChunker : IEnumerable<WeekChunk>
    {
        private readonly IEnumerable<IDag> dagen;

        public WeekChunker(IEnumerable<IDag> dagen)
        {
            this.dagen = dagen.OrderBy(d => d.Date);
        }

        public IEnumerator<WeekChunk> GetEnumerator()
        {
            ICollection<IDag> buffer = new List<IDag>();
            foreach (var dag in dagen)
            {
                if(dag.DayOfWeek == DayOfWeek.Monday || dag.DayOfWeek == DayOfWeek.Thursday)
                {
                    if(buffer.Count > 0)
                        yield return new WeekChunk(buffer);
                    buffer = new List<IDag>();
                }
                buffer.Add(dag);
            }
            yield return new WeekChunk(buffer);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class WeekChunk
    {
        private readonly IEnumerable<IDag> dagen;

        public WeekChunk(IEnumerable<IDag> dagen)
        {
            this.dagen = dagen.OrderBy(d => d.Date);
        }

        public DayOfWeek DayOfWeek
        {
            get { return dagen.First().DayOfWeek; }
        }

        public IEnumerable<IDag> Days
        {
            get { return dagen; }
        }
    }
}