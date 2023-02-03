using System;
using System.Collections.Generic;
using System.Web;
using System.Reflection;
using Newtonsoft.Json;
using HexTest.Application;
using HexTest.Application.Interfaces;
using HexTest.SharedKernel;

public class DummyTask : BaseTask
{
	public Tuple<object,string> Execute(object slcp_user)
	{
			
		//var op0_input = JsonConvert.SerializeObject("{'argument1':'" + slcp_user.slcp_uid +"','argument2':'" + slcp_user.slcp_username +"','argument3':'" + slcp_user.slcp_dayname + "','argument4':'" + slcp_user.slcp_status + "',}");
		//dynamic op0_result = JsonConvert.DeserializeObject(HexTest.Application.Actions.Action.assignment(op0_input));
			
		//slcp_user new_slcp_user = new slcp_user();
		//new_slcp_user.slcp_uid = op0_result.argument1;
		//new_slcp_user.slcp_username = op0_result.argument2;
		//new_slcp_user.slcp_dayname = op0_result.argument3;
		//new_slcp_user.slcp_status = op0_result.argument4;

		//IUnitOfWork unitOfWork = Common.UnitOfWork.GetUnitOfWork();

		//Check if User Exists 
		//Task<IReadOnlyList<slcp_user>> res_slcp_user = unitOfWork.slcp_userRepository.ListAllAsync(new CancellationToken(false));

		//res_slcp_user.Wait();

		//if(res_slcp_user.Result.Where<slcp_user>(u => u.slcp_uid == new_slcp_user.slcp_uid).Count() > 1)
		//      {
		//	//Raise Not Valid Event
		//	return new Tuple<object, string>(new_slcp_user, "Invalid");
		//}
		//else
		//      {
		//	Task<slcp_user> result_slcp_user = unitOfWork.slcp_userRepository.AddAsync(new_slcp_user, new CancellationToken(false));

		//	result_slcp_user.Wait();

		//	return new Tuple<object, string>(result_slcp_user.Result, "Registration Done");
		//}


		return new Tuple<object, string>(slcp_user, "Registration Done");

	}
}
//}//End of Namespace