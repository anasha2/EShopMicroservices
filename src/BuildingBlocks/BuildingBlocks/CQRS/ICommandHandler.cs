using MediatR;

namespace BuildingBlocks.CQRS;
// handle interface without response if there is no respons it will be generated from unit object
public interface ICommandHandler<in TCommand>
    : ICommandHandler<TCommand, Unit>
    where TCommand : ICommand<Unit>
{

}
//handle interface for command that is used to send a request to the command handler and get response
public interface ICommandHandler<in TCommand, TResponse> 
    : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
   where TResponse: notnull
{
}
