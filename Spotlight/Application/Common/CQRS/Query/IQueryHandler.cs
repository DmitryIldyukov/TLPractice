namespace Application.Common.CQRS.Query;

public interface IQueryHandler<in TQueryParameter, TResult>
    where TQueryParameter : class
    where TResult : class
{
    Task<TResult> GetQueryAsync(TQueryParameter query);
}
