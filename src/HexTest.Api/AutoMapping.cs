using AutoMapper;
using HexTest.Api.Endpoints.slcp_employees;
using HexTest.Core.slcp_employeeAggregate;
using HexTest.Api.Endpoints.slcp_departments;
using HexTest.Core.slcp_departmentAggregate;
using HexTest.Api.Endpoints.slcp_cars;
using HexTest.Core.slcp_carAggregate;
using HexTest.Api.Endpoints.jobs;
using HexTest.Core.jobAggregate;
using HexTest.Api.Endpoints.slcp_registration_CF1s;
using HexTest.Core.slcp_registration_CF1Aggregate;
using HexTest.Api.Endpoints.slcp_employee_department_maps;
using HexTest.Core.slcp_employee_department_mapAggregate;
//<#AddNamespace#>


namespace HexTest.Api;

public class AutoMapping : Profile
{
  public AutoMapping()
  {
    //############  Mappings for slcp_employee ###############
CreateMap<Createslcp_employeeCommand, slcp_employee>();
CreateMap<Updateslcp_employeeCommand, slcp_employee>();
CreateMap<Updateslcp_employeeCommandById, slcp_employee>();
CreateMap<slcp_employee , Createslcp_employeeResult>();
CreateMap<slcp_employee , Updatedslcp_employeeResult>();
CreateMap<slcp_employee , Updatedslcp_employeeByIdResult>();
CreateMap<slcp_employee , slcp_employeeListResult>();
CreateMap<slcp_employee , slcp_employeeGetByQueryResult>();
CreateMap<slcp_employee , slcp_employeeResult>();

//############  Mappings for slcp_department ###############
CreateMap<Createslcp_departmentCommand, slcp_department>();
CreateMap<Updateslcp_departmentCommand, slcp_department>();
CreateMap<Updateslcp_departmentCommandById, slcp_department>();
CreateMap<slcp_department , Createslcp_departmentResult>();
CreateMap<slcp_department , Updatedslcp_departmentResult>();
CreateMap<slcp_department , Updatedslcp_departmentByIdResult>();
CreateMap<slcp_department , slcp_departmentListResult>();
CreateMap<slcp_department , slcp_departmentGetByQueryResult>();
CreateMap<slcp_department , slcp_departmentResult>();

//############  Mappings for slcp_car ###############
CreateMap<Createslcp_carCommand, slcp_car>();
CreateMap<Updateslcp_carCommand, slcp_car>();
CreateMap<Updateslcp_carCommandById, slcp_car>();
CreateMap<slcp_car , Createslcp_carResult>();
CreateMap<slcp_car , Updatedslcp_carResult>();
CreateMap<slcp_car , Updatedslcp_carByIdResult>();
CreateMap<slcp_car , slcp_carListResult>();
CreateMap<slcp_car , slcp_carGetByQueryResult>();
CreateMap<slcp_car , slcp_carResult>();

//############  Mappings for job ###############
CreateMap<CreatejobCommand, job>();
CreateMap<UpdatejobCommand, job>();
CreateMap<UpdatejobCommandById, job>();
CreateMap<job , CreatejobResult>();
CreateMap<job , UpdatedjobResult>();
CreateMap<job , UpdatedjobByIdResult>();
CreateMap<job , jobListResult>();
CreateMap<job , jobGetByQueryResult>();
CreateMap<job , jobResult>();

//############  Mappings for slcp_registration_CF1 ###############
CreateMap<Createslcp_registration_CF1Command, slcp_registration_CF1>();
CreateMap<Updateslcp_registration_CF1Command, slcp_registration_CF1>();
CreateMap<Updateslcp_registration_CF1CommandById, slcp_registration_CF1>();
CreateMap<slcp_registration_CF1 , Createslcp_registration_CF1Result>();
CreateMap<slcp_registration_CF1 , Updatedslcp_registration_CF1Result>();
CreateMap<slcp_registration_CF1 , Updatedslcp_registration_CF1ByIdResult>();
CreateMap<slcp_registration_CF1 , slcp_registration_CF1ListResult>();
CreateMap<slcp_registration_CF1 , slcp_registration_CF1GetByQueryResult>();
CreateMap<slcp_registration_CF1 , slcp_registration_CF1Result>();

//############  Mappings for slcp_employee_department_map ###############
CreateMap<Createslcp_employee_department_mapCommand, slcp_employee_department_map>();
CreateMap<Updateslcp_employee_department_mapCommand, slcp_employee_department_map>();
CreateMap<Updateslcp_employee_department_mapCommandById, slcp_employee_department_map>();
CreateMap<slcp_employee_department_map , Createslcp_employee_department_mapResult>();
CreateMap<slcp_employee_department_map , Updatedslcp_employee_department_mapResult>();
CreateMap<slcp_employee_department_map , Updatedslcp_employee_department_mapByIdResult>();
CreateMap<slcp_employee_department_map , slcp_employee_department_mapListResult>();
CreateMap<slcp_employee_department_map , slcp_employee_department_mapGetByQueryResult>();
CreateMap<slcp_employee_department_map , slcp_employee_department_mapResult>();

//<#Mappings#>
  }
}
