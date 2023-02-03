using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Data;
using HexTest.WebUI.Models;
using FluentValidation;

namespace HexTest
{
	public class slcp_wheelValidator : AbstractValidator<slcp_wheel>
	{
		public slcp_wheelValidator()
			{
			RuleFor(x => x.slcp_type).NotEmpty().WithMessage("Please specify Type.");
			RuleFor(x => x.slcp_type).Length(1,200).WithMessage("Please specify Length between 1&200.");
			}


	}//End Of Class
}//End Of Namespace