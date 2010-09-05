namespace Agendas.Infrastructure
{
    public interface IQueryResult<T>
    {
        T UniqueResult();
    }
}