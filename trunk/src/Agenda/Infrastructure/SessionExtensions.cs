using NHibernate;

namespace Agendas.Infrastructure
{
    public static class SessionExtensions
    {
        public static IQueryResult<T> Query<T>(this ISession session, IQuery<T> request)
        {
            return request.Execute(session);
        }
    }
}