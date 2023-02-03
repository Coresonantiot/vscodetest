using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using MediatR;
using HexTest.Core.Interfaces;
using HexTest.Core.slcp_carAggregate.Events;
//<#AddNamespaces#>


namespace HexTest.Core.slcp_carAggregate.Handlers;

public class DummyHandler : INotificationHandler<DummyEvent>
{ 
  public Task Handle(DummyEvent dummyEvent, CancellationToken cancellationToken)
  {
    return null;
  }
}