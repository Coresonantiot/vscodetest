using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Data;
using HexTest.WebUI.Models;
using FluentValidation;

namespace HexTest
{
	public class slcp_employeeValidator : AbstractValidator<slcp_employee>
	{
		public slcp_employeeValidator()
			{
			RuleFor(x => x.slcp_emp_code).NotEmpty().WithMessage("Please specify Emp Code.");
			RuleFor(x => x.slcp_emp_code).Length(1,200).WithMessage("Please specify Length between 1&200.");
			}


	}//End Of Class
}//End Of Namespace