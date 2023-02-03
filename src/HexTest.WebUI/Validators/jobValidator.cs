using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Data;
using HexTest.WebUI.Models;
using FluentValidation;

namespace HexTest
{
	public class jobValidator : AbstractValidator<job>
	{
		public jobValidator()
			{
			RuleFor(x => x.jname).NotEmpty().WithMessage("Please specify Job Name.");
			RuleFor(x => x.jname).Length(0,500).WithMessage("Please specify Length between 0&500.");
			RuleFor(x => x.description).NotEmpty().WithMessage("Please specify Description.");
			RuleFor(x => x.description).Length(0,200).WithMessage("Please specify Length between 0&200.");
			RuleFor(x => x.processid).NotEmpty().WithMessage("Please specify Process Id.");
			RuleFor(x => x.processid).Length(0,200).WithMessage("Please specify Length between 0&200.");
			RuleFor(x => x.process_name).NotEmpty().WithMessage("Please specify Process Name.");
			RuleFor(x => x.process_name).Length(0,200).WithMessage("Please specify Length between 0&200.");
			RuleFor(x => x.recureevery).NotEmpty().WithMessage("Please specify Recure Every.");
			RuleFor(x => x.recureevery).Length(1,200).WithMessage("Please specify Length between 1&200.");
			RuleFor(x => x.recureweek).NotEmpty().WithMessage("Please specify Recure Week.");
			RuleFor(x => x.recureweek).Length(1,200).WithMessage("Please specify Length between 1&200.");
			}


	}//End Of Class
}//End Of Namespace