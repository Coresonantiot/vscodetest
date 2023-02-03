using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Data;
using HexTest.WebUI.Models;
using FluentValidation;

namespace HexTest
{
	public class slcp_engineValidator : AbstractValidator<slcp_engine>
	{
		public slcp_engineValidator()
			{
			RuleFor(x => x.slcp_engine_number).NotEmpty().WithMessage("Please specify Engine Number.");
			RuleFor(x => x.slcp_engine_number).Length(1,200).WithMessage("Please specify Length between 1&200.");
			}


	}//End Of Class
}//End Of Namespace