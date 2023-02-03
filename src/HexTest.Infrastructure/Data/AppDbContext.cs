using Ardalis.EFCore.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using HexTest.SharedKernel;
using HexTest.Core.ProcessAggregate;
using HexTest.Application.Interfaces;
using HexTest.Core.slcp_employeeAggregate;
using HexTest.Core.slcp_departmentAggregate;
using HexTest.Core.slcp_carAggregate;
using HexTest.Core.jobAggregate;
using HexTest.Core.slcp_registration_CF1Aggregate;
using HexTest.Core.slcp_employee_department_mapAggregate;
//<#AddNamespaces#>


namespace HexTest.Infrastructure.Data;

public class AppDbContext : DbContext
{
    private readonly IMediator? _mediator;
    private object _locker = new object();

    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    public AppDbContext(DbContextOptions<AppDbContext> options, IMediator? mediator) : base(options)
    {
        _mediator = mediator;
    }

    
    public DbSet<EventInstance> EventInstances => Set<EventInstance>();
    public DbSet<EventMaster> EventMasters => Set<EventMaster>();
    public DbSet<FeatureProcessMap> FeatureProcessMaps => Set<FeatureProcessMap>();
    public DbSet<ProcessInstance> ProcessInstances => Set<ProcessInstance>();
    public DbSet<ProcessMaster> ProcessMasters => Set<ProcessMaster>();
    public DbSet<ProcessTaskMap> ProcessTaskMaps => Set<ProcessTaskMap>();
    public DbSet<TaskInstance> TaskInstances => Set<TaskInstance>();
    public DbSet<TaskMaster> TaskMasters => Set<TaskMaster>();
    public DbSet<ProcessProdModule> ProcessProdModules => Set<ProcessProdModule>();
    public DbSet<ProcessTaskMapView> ProcessTaskMapViews => Set<ProcessTaskMapView>();
    
    //Add DbSet's Here as below for each Entity    
    public DbSet<slcp_employee> slcp_employees => Set<slcp_employee>();
		public DbSet<slcp_department> slcp_departments => Set<slcp_department>();
		public DbSet<slcp_car> slcp_cars => Set<slcp_car>();
		public DbSet<job> jobs => Set<job>();
		public DbSet<slcp_registration_CF1> slcp_registration_CF1s => Set<slcp_registration_CF1>();
		public DbSet<slcp_employee_department_map> slcp_employee_department_maps => Set<slcp_employee_department_map>();
//<#AddDBSet#>

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (Common.Database == "PostgreSQL")
        {
            modelBuilder.HasDefaultSchema("public");
        }        

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
    }
  
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        // ignore events if no dispatcher provided
        if (_mediator == null) return result;

        // dispatch events only if save was successful
        var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
            .Select(e => e.Entity)
            .Where(e => e.Events.Any())
            .ToArray();

        foreach (var entity in entitiesWithEvents)
        {
            var events = entity.Events.ToArray();
            entity.Events.Clear();
            foreach (var domainEvent in events)
            {
                await _mediator.Publish(domainEvent).ConfigureAwait(false);
            }
        }

        return result;
    }

    public override int SaveChanges()
    {
        lock (_locker)
        {
            Task<int> saveTask = SaveChangesAsync();
            saveTask.Wait();
            return saveTask.Result;
        }
    }
}
