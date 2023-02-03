using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using MediatR;
using HexTest.Core.Interfaces;
using HexTest.Core.slcp_employee_department_mapAggregate.Events;
//<#AddNamespaces#>


namespace HexTest.Core.slcp_employee_department_mapAggregate.Handlers;

public class DummyHandler : INotificationHandler<DummyEvent>
{ 
  public Task Handle(DummyEvent dummyEvent, CancellationToken cancellationToken)
  {
    return null;
  }
}