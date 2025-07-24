using MediatR;


namespace BuildingBlocks.CQRS
{
    public interface ICommand: ICommand<Unit>
    {

    }
    //abstraction for command that is used to send a request to the command handler
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
