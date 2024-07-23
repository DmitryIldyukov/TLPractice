namespace Application.Common.CQRS.Command;

public interface ICommandHandler<in TCommand, TResult>
    where TCommand : class
    where TResult : class
{
    Task<TResult> HandlerAsync(TCommand command);
}
