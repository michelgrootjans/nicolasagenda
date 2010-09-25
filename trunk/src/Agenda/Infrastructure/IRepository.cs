namespace Agendas.Infrastructure
{
    public interface IRepository
    {
        IQueryResult<T> Query<T>(IQuery<T> query);
    }
}