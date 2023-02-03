using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Data;
using HexTest.WebUI.Models;
using FluentValidation;

namespace HexTest
{
	public class slcp_carValidator : AbstractValidator<slcp_car>
	{
		public slcp_carValidator()
			{
			RuleFor(x => x.slcp_colour).NotEmpty().WithMessage("Please specify Colour.");
			RuleFor(x => x.slcp_colour).Length(1,200).WithMessage("Please specify Length between 1&200.");
			}


	}//End Of Class
}//End Of Namespace