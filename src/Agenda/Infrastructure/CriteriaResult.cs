using NHibernate;

namespace Agendas.Infrastructure
{
    public class CriteriaResult<T> : IQueryResult<T>
    {
        private readonly ICriteria criteria;

        public CriteriaResult(ICriteria criteria)
        {
            this.criteria = criteria;
        }

        public T UniqueResult()
        {
            return criteria.UniqueResult<T>();
        }
    }
}