using Ardalis.Specification;
using HexTest.Core.ProcessAggregate;

namespace HexTest.Core.ProcessAggregate.Specifications;

public class ProcessWithTasksAndEventsSpec : Specification<ProcessMaster>, ISingleResultSpecification
{
  public ProcessWithTasksAndEventsSpec(string procName)
  {
        Query
            .Where(processMaster => processMaster.Name == procName)            
            .OrderBy(processMaster => processMaster.Id);
  }
}
