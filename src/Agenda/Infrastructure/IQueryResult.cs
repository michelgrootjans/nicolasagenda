using System.Collections.Generic;

namespace Agendas.Infrastructure
{
    public interface IQueryResult<T>
    {
        T UniqueResult();
        IEnumerable<T> List();
    }
}