using NHibernate;

namespace Agendas.Infrastructure
{
    public interface IQuery<T>
    {
        IQueryResult<T> Execute(ISession session);
    }
}