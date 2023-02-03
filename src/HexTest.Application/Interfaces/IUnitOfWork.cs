using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexTest.SharedKernel.Interfaces;
using HexTest.Core.ProcessAggregate;
using HexTest.Core.slcp_employeeAggregate;
using HexTest.Core.slcp_departmentAggregate;
using HexTest.Core.slcp_carAggregate;
using HexTest.Core.jobAggregate;
using HexTest.Core.slcp_registration_CF1Aggregate;
using HexTest.Core.slcp_employee_department_mapAggregate;
//<#AddNamespaces#>

namespace HexTest.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public IUnitOfWork GetUnitOfWork();
        public void CreateTransaction();
        public void Commit();
        public void Rollback();
        public void Save();
        public IAsyncRepository<ProcessMaster> ProcessMasterRepository { get; } 
        public IAsyncRepository<EventInstance> EventInstanceRepository { get; }
        public IAsyncRepository<EventMaster> EventMasterRepository { get; }
        public IAsyncRepository<FeatureProcessMap> FeatureProcessMapRepository { get; }
        public IAsyncRepository<ProcessInstance> ProcessInstanceRepository { get; }
        public IAsyncRepository<ProcessTaskMap> ProcessTaskMapRepository { get; }
        public IAsyncRepository<TaskInstance> TaskInstanceRepository { get; }
        public IAsyncRepository<TaskMaster> TaskMasterRepository { get; }
        public IAsyncRepository<ProcessProdModule> ProcessProdModuleRepository { get; }
        public IAsyncRepository<ProcessTaskMapView> ProcessTaskMapViewRepository { get; }

        //Add All Entity As Repositories
        public IAsyncRepository<slcp_employee> slcp_employeeRepository { get; }
		public IAsyncRepository<slcp_department> slcp_departmentRepository { get; }
		public IAsyncRepository<slcp_car> slcp_carRepository { get; }
		public IAsyncRepository<job> jobRepository { get; }
		public IAsyncRepository<slcp_registration_CF1> slcp_registration_CF1Repository { get; }
		public IAsyncRepository<slcp_employee_department_map> slcp_employee_department_mapRepository { get; }
//<#IUnitOfWorkDeclartion>
    }
}
