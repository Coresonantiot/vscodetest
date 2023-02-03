using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Data;
using Newtonsoft.Json;
using HexTest.WebUI.Workflows.Arguments;
using HexTest.WebUI.Utilities;

namespace HexTest.WebUI.DataAccessLayer
{
    public class ApiHandler
    {
        private RestClient client = new RestClient(Common.ProjectProperties.get("EndPointUrl"));
        
        public T Save<T>(T obj)
        {
            string name = typeof(T).Name + "s";            
            RestRequest request = new RestRequest(name, Method.Post);
            request.AddBody(obj, "application/json");
            var response = client.Execute<T>(request);
            return response.Data;
        }

        public T GetById<T>(int id)
        {
            string name = typeof(T).Name + "s";
            RestRequest request = new RestRequest(name + '/' + id, Method.Get);
            RestResponse<T> response = client.Execute<T>(request);
            return response.Data;
        }

        public List<T> Get<T>(int id = 0, string includeProperties = "")
        {
            string name = typeof(T).Name + "s";
            RestRequest request = new RestRequest(name + "/GetByQuery", Method.Get);
            request.AddParameter("Id", id, ParameterType.QueryString);
            request.AddParameter("includeProperties", includeProperties, ParameterType.QueryString);
            RestResponse<List<T>> response = client.Execute<List<T>>(request);
            return response.Data;
        }
        
        public void Update<T>(T obj)
        {
            string name = typeof(T).Name + "s";
            RestRequest request = new RestRequest(name, Method.Put);
            request.AddBody(obj, "application/json");
            client.Execute<T>(request);
        }
        
        public List<T> GetAll<T>()
        {
            string name = typeof(T).Name + "s";
            RestRequest request = new RestRequest(name, Method.Get);
            RestResponse<List<T>> response = client.Execute<List<T>>(request);
            return response.Data;
        }

        public void Delete<T>(int id)
        {
            string name = typeof(T).Name + "s";
            RestRequest request = new RestRequest(name + '/' + id, Method.Delete);
            client.Execute<T>(request);
        }
        public string GetAll(string table)
        {
            string name = table + "s";
            RestRequest request = new RestRequest(name, Method.Get);
            RestResponse response = client.Execute(request);
            return response.Content;
        }
        public DataTable GetQueryResult(string route, string query)
        {
            RestRequest request = new RestRequest(route, Method.Get);
            request.AddParameter("query", query);
            RestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<DataTable>(response.Content); ;
        }

        public ProcessOutputArgs GetProcessResult(string pname, object process_input)
        {
            RestRequest request = new RestRequest(pname, Method.Post);
            request.AddJsonBody(process_input);
            RestResponse<ProcessOutputArgs> response = client.Execute<ProcessOutputArgs>(request);
            return response.Data;
        }
    }
}
