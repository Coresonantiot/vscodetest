using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Data;
using HexTest.WebUI.Models;
using FluentValidation;

namespace HexTest
{
	public class slcp_departmentValidator : AbstractValidator<slcp_department>
	{
		public slcp_departmentValidator()
			{
			RuleFor(x => x.slcp_dept_name).NotEmpty().WithMessage("Please specify Department Name.");
			RuleFor(x => x.slcp_dept_name).Length(1,200).WithMessage("Please specify Length between 1&200.");
			RuleFor(x => x.slcp_dept_code).NotEmpty().WithMessage("Please specify Department Code.");
			RuleFor(x => x.slcp_dept_code).Length(1,200).WithMessage("Please specify Length between 1&200.");
			}


	}//End Of Class
}//End Of Namespace