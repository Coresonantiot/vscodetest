using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using HexTest.WebUI.Utilities;


namespace HexTest.WebUI.DataAccessLayer
{
    public class DAL_Extension
    {
		private string ConnectionString = @"Server=" + Common.ProjectProperties.get("HostName") + "; Port = " + Common.ProjectProperties.get("Port") + "; Uid = " + Common.ProjectProperties.get("UserID") + "; Pwd = " + Common.ProjectProperties.get("Password") + "; Database = " + Common.ProjectProperties.get("DatabaseName") + "; ";
		public  List<T> ConvertToList<T>(DataTable dt)
		{
			var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
			var properties = typeof(T).GetProperties();
			return dt.AsEnumerable().Select(row => {
				var objT = Activator.CreateInstance<T>();
				foreach (var pro in properties)
				{
					if (columnNames.Contains(pro.Name.ToLower()))
					{
						try
						{
							pro.SetValue(objT, row[pro.Name], null);
						}
						catch (Exception) { }
					}
				}
				return objT;
			}).ToList();
		}
		
	}
}
