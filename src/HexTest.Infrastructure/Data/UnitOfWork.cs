using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using HexTest.SharedKernel.Interfaces;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore;
using HexTest.Application.Interfaces;
using HexTest.Application;
using HexTest.Core.ProcessAggregate;
using HexTest.Core.slcp_employeeAggregate;
using HexTest.Core.slcp_departmentAggregate;
using HexTest.Core.slcp_carAggregate;
using HexTest.Core.jobAggregate;
using HexTest.Core.slcp_registration_CF1Aggregate;
using HexTest.Core.slcp_employee_department_mapAggregate;
//<#AddNamespaces#>


namespace HexTest.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private AppDbContext context;
        private IDbContextTransaction transaction;
        private GenericRepository<EventInstance> eventInstanceRepository { get; }
        private GenericRepository<EventMaster> eventMasterRepository { get; }
        private GenericRepository<FeatureProcessMap> featureProcessMapRepository { get; }
        private GenericRepository<ProcessInstance> processInstanceRepository { get; }
        private GenericRepository<ProcessMaster> processMasterRepository { get; }
        private GenericRepository<ProcessTaskMap> processTaskMapRepository { get; }
        private GenericRepository<TaskInstance> taskInstanceRepository { get; }
        private GenericRepository<TaskMaster> taskMasterRepository { get; }
        private GenericRepository<ProcessProdModule> processProdModuleRepository { get; }
        private GenericRepository<ProcessTaskMapView> processTaskMapViewRepository { get; }
        private GenericRepository<slcp_employee> _slcp_employeeRepository { get; }
		private GenericRepository<slcp_department> _slcp_departmentRepository { get; }
		private GenericRepository<slcp_car> _slcp_carRepository { get; }
		private GenericRepository<job> _jobRepository { get; }
		private GenericRepository<slcp_registration_CF1> _slcp_registration_CF1Repository { get; }
		private GenericRepository<slcp_employee_department_map> slcp_employee_department_maprepository{ get; }
//<#UnitOfWorkVarDeclartion#>

        public UnitOfWork()
        {
            context = new AppDbContext(GetDbContextOptions());
            //Make the Connection Open And Ready
            try
            {
                context.ProcessMasters.Load();                
            }
            catch { }
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return new UnitOfWork();
        }

        public void CreateTransaction()
        {
            transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (transaction != null)
            {
                Task t = transaction.CommitAsync();
                t.Wait();
            }
        }

        public void Rollback()
        {
            if (transaction != null)
            {
                Task t = transaction.RollbackAsync();
                t.Wait();
            }
        }

        private DbContextOptions<AppDbContext> GetDbContextOptions()
        { 
            DbContextOptions<AppDbContext> dbContextOptionsoptions;

            switch (Common.Database)
            {
                case "MySql":
                    dbContextOptionsoptions = new DbContextOptionsBuilder<AppDbContext>()
                         .UseMySql(HexTest.Infrastructure.Data.Common.ConnectionString, ServerVersion.Create(5, 5, 0, Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql), null)
                        .Options;                    
                    break;
                case "MariaDB":
                    dbContextOptionsoptions = new DbContextOptionsBuilder<AppDbContext>()
                        .UseMySql(HexTest.Infrastructure.Data.Common.ConnectionString, ServerVersion.Create(5, 5, 0, Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MariaDb), null)
                        .Options;
                    break;
                case "MSSqlServer":
                    dbContextOptionsoptions = new DbContextOptionsBuilder<AppDbContext>()
                        .UseSqlServer(Common.ConnectionString)
                        .Options;
                    break;
                case "SQLite":
                    dbContextOptionsoptions = new DbContextOptionsBuilder<AppDbContext>()
                        .UseSqlite(Common.ConnectionString)
                        .Options;
                    break;
                case "Oracle":
                    dbContextOptionsoptions = new DbContextOptionsBuilder<AppDbContext>()
                        .UseOracle(Common.ConnectionString)
                        .Options;
                    break;
                default:
                    dbContextOptionsoptions = new DbContextOptionsBuilder<AppDbContext>()
                        .UseMySql(HexTest.Infrastructure.Data.Common.ConnectionString, ServerVersion.Create(5, 5, 0, Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql), null)
                        .Options;
                    break;
            }

            return dbContextOptionsoptions;
        }

        public IAsyncRepository<ProcessMaster> ProcessMasterRepository { get { return this.processMasterRepository ?? new GenericRepository<ProcessMaster>(context); } }
        public IAsyncRepository<EventInstance> EventInstanceRepository { get { return this.eventInstanceRepository ?? new GenericRepository<EventInstance>(context); } }
        public IAsyncRepository<EventMaster> EventMasterRepository { get { return this.eventMasterRepository ?? new GenericRepository<EventMaster>(context); } }
        public IAsyncRepository<FeatureProcessMap> FeatureProcessMapRepository { get { return this.featureProcessMapRepository ?? new GenericRepository<FeatureProcessMap>(context); } }
        public IAsyncRepository<ProcessInstance> ProcessInstanceRepository { get { return this.processInstanceRepository ?? new GenericRepository<ProcessInstance>(context); } }
        public IAsyncRepository<ProcessTaskMap> ProcessTaskMapRepository { get { return this.processTaskMapRepository ?? new GenericRepository<ProcessTaskMap>(context); } }
        public IAsyncRepository<TaskInstance> TaskInstanceRepository { get { return this.taskInstanceRepository ?? new GenericRepository<TaskInstance>(context); } }
        public IAsyncRepository<TaskMaster> TaskMasterRepository { get { return this.taskMasterRepository ?? new GenericRepository<TaskMaster>(context); } }
        public IAsyncRepository<ProcessProdModule> ProcessProdModuleRepository { get { return this.processProdModuleRepository ?? new GenericRepository<ProcessProdModule>(context); } }
        public IAsyncRepository<ProcessTaskMapView> ProcessTaskMapViewRepository { get { return this.processTaskMapViewRepository ?? new GenericRepository<ProcessTaskMapView>(context); } }        
        public IAsyncRepository<slcp_employee> slcp_employeeRepository { get { return this._slcp_employeeRepository ?? new GenericRepository<slcp_employee>(context); } }
		public IAsyncRepository<slcp_department> slcp_departmentRepository { get { return this._slcp_departmentRepository ?? new GenericRepository<slcp_department>(context); } }
		public IAsyncRepository<slcp_car> slcp_carRepository { get { return this._slcp_carRepository ?? new GenericRepository<slcp_car>(context); } }
		public IAsyncRepository<job> jobRepository { get { return this._jobRepository ?? new GenericRepository<job>(context); } }
		public IAsyncRepository<slcp_registration_CF1> slcp_registration_CF1Repository { get { return this._slcp_registration_CF1Repository ?? new GenericRepository<slcp_registration_CF1>(context); } }
		public IAsyncRepository<slcp_employee_department_map> slcp_employee_department_mapRepository { get { return this.slcp_employee_department_maprepository ?? new GenericRepository<slcp_employee_department_map>(context); } }
//<#UnitOfWorkImpl#>

        public void Save()
        {   
            context.SaveChanges();
        }


        private bool disposed = false; protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
