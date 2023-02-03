using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Data;

namespace HexTest
{
	public class FileExtentionValidator
	{
		 private string AcceptExtentions { get; set; }
				public FileExtentionValidator(string AcceptExtentions)
	{
				this.AcceptExtentions = AcceptExtentions;
	}
		public bool IsValidFileType(string filename)
	{
				string[] filaname = filename.Split(',');
				string[] ext = AcceptExtentions.Split(',');
				foreach (var s in ext)
						if (filaname[0].ToUpper() == s.ToUpper())
								return true;
				return false;
		}
	}
}//End Of Namespace