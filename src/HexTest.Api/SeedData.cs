using HexTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using HexTest.Application.Workflows;
using HexTest.Application.Workflows.Arguments;
using Serilog;
//<#AddNamespaces#>

namespace HexTest.Api;

public static class SeedData
{
  public static void Initialize(IServiceProvider serviceProvider)
  {
        string sqlDropTableProcessTaskMapViews = "";
        string sqlCreateViewProcessTaskMapViews = "";

        using (var dbContext = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
        {
            //Master Data Seeding Activity for First Run
            switch (HexTest.Infrastructure.Data.Common.Database)
            {
                case "MySql":
                    //Drop Table processtaskmapviews
                    sqlDropTableProcessTaskMapViews = "Drop Table ProcessTaskMapViews;";

                    //Create View processtaskmapviews
                    sqlCreateViewProcessTaskMapViews = "CREATE VIEW ProcessTaskMapViews AS " +
                        "(SELECT ptm.id, pm.id process_id, pm.name process_name, tm.id task_id, tm.name task_name, em.id event_id, em.name event_name," +
                        "(SELECT dbMname FROM ProcessProdModules WHERE id = tm.inputdata) input_data FROM ProcessTaskMaps ptm " +
                        "INNER JOIN ProcessMasters pm ON pm.id = ptm.processid " +
                        "INNER JOIN TaskMasters tm ON tm.id = ptm.taskid " +
                        "INNER JOIN EeventMasters em ON em.id = tm.inputevent);";

                    Log.Information("Executing : Drop Table ProcessTaskMapViews");
                    Log.Information("Result :" + dbContext.Database.ExecuteSqlRaw(sqlDropTableProcessTaskMapViews));
                    Log.Information("Executing : Create View ProcessTaskMapViews");
                    Log.Information("Result :" + dbContext.Database.ExecuteSqlRaw(sqlCreateViewProcessTaskMapViews));

                    dbContext.SaveChanges();
                    //<Insert_Master_Data>
                    break;
                case "MSSqlServer":                    
                    break;
                case "SQLite":                    
                    break;
                case "Oracle":                    
                    break;
                case "PostgreSQL":
                    //Setting default Schema to public
                    //Log.Information("Executing : SET search_path = 'public';");
                    //Log.Information("Result :" + dbContext.Database.ExecuteSqlRaw("SET search_path = 'public';"));

                    //Drop Table processtaskmapviews
                    sqlDropTableProcessTaskMapViews = "Drop Table \"ProcessTaskMapViews\";";

                    //Create View processtaskmapviews
                    sqlCreateViewProcessTaskMapViews = "CREATE VIEW \"ProcessTaskMapViews\" AS " +
                        "(SELECT ptm.id, pm.id process_id, pm.name process_name, tm.id task_id, tm.name task_name, em.id event_id, em.name event_name," +
                        "(SELECT dbMname FROM \"ProcessProdModules\" WHERE id = tm.inputdata) input_data FROM \"ProcessTaskMaps\" ptm " +
                        "INNER JOIN \"ProcessMasters\" pm ON pm.id = ptm.processid " +
                        "INNER JOIN \"TaskMasters\" tm ON tm.id = ptm.taskid " +
                        "INNER JOIN \"EeventMasters\" em ON em.id = tm.inputevent);";

                    Log.Information("Executing : Drop Table \"ProcessTaskMapViews\"");
                    Log.Information("Result :" + dbContext.Database.ExecuteSqlRaw(sqlDropTableProcessTaskMapViews));
                    Log.Information("Executing : Create View \"ProcessTaskMapViews\"");
                    Log.Information("Result :" + dbContext.Database.ExecuteSqlRaw(sqlCreateViewProcessTaskMapViews));

                    dbContext.SaveChanges();
                    //<Insert_Master_Data>
                    break;
                default:
                    //Drop Table processtaskmapviews
                    sqlDropTableProcessTaskMapViews = "Drop Table ProcessTaskMapViews;";

                    //Create View processtaskmapviews
                    sqlCreateViewProcessTaskMapViews = "CREATE VIEW ProcessTaskMapViews AS " +
                        "(SELECT ptm.id, pm.id process_id, pm.name process_name, tm.id task_id, tm.name task_name, em.id event_id, em.name event_name," +
                        "(SELECT dbMname FROM ProcessProdModules WHERE id = tm.inputdata) input_data FROM ProcessTaskMaps ptm " +
                        "INNER JOIN ProcessMasters pm ON pm.id = ptm.processid " +
                        "INNER JOIN TaskMasters tm ON tm.id = ptm.taskid " +
                        "INNER JOIN EeventMasters em ON em.id = tm.inputevent);";

                    Log.Information("Executing : Drop Table ProcessTaskMapViews");
                    Log.Information("Result :" + dbContext.Database.ExecuteSqlRaw(sqlDropTableProcessTaskMapViews));
                    Log.Information("Executing : Create View ProcessTaskMapViews");
                    Log.Information("Result :" + dbContext.Database.ExecuteSqlRaw(sqlCreateViewProcessTaskMapViews));

                    dbContext.SaveChanges();
                    //<Insert_Master_Data>
                    break;
            }

            
        }
  }
}
