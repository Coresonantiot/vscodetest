using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Data;
using HexTest.WebUI.Models;
using FluentValidation;

namespace HexTest
{
	public class slcp_registration_CF1Validator:AbstractValidator<slcp_registration_CF1>
	{
		public slcp_registration_CF1Validator()
		{
			RuleFor(x => x.slcp_registration_CF1_slcp_employee.slcp_emp_code).NotEmpty().WithMessage("Please specify Emp Code.");
			RuleFor(x => x.slcp_registration_CF1_slcp_employee.slcp_emp_code).Length(1,200).WithMessage("Please specify Length between 1&200.");




			RuleFor(x => x.slcp_registration_CF1_slcp_department.slcp_dept_name).NotEmpty().WithMessage("Please specify Department Name.");
			RuleFor(x => x.slcp_registration_CF1_slcp_department.slcp_dept_name).Length(1,200).WithMessage("Please specify Length between 1&200.");


			RuleFor(x => x.slcp_registration_CF1_slcp_department.slcp_dept_code).NotEmpty().WithMessage("Please specify Department Code.");
			RuleFor(x => x.slcp_registration_CF1_slcp_department.slcp_dept_code).Length(1,200).WithMessage("Please specify Length between 1&200.");


		}//End Of Class
	}//End Of Class
}//End Of Namespace