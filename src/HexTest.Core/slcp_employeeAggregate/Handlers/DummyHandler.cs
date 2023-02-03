using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using MediatR;
using HexTest.Core.Interfaces;
using HexTest.Core.slcp_employeeAggregate.Events;
//<#AddNamespaces#>


namespace HexTest.Core.slcp_employeeAggregate.Handlers;

public class DummyHandler : INotificationHandler<DummyEvent>
{ 
  public Task Handle(DummyEvent dummyEvent, CancellationToken cancellationToken)
  {
    return null;
  }
}