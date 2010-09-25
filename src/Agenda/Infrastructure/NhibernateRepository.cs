namespace Agendas.Infrastructure
{
    internal class NhibernateRepository : IRepository
    {
        public IQueryResult<T> Query<T>(IQuery<T> query)
        {
            return NHibernateProvider.CreateSession().Query(query);
        }
    }
}