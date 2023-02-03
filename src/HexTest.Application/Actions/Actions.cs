using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HexTest.Application.Actions
{
    public partial class Action
    {
        public static string add(string input)
        {
            dynamic a = JArray.Parse(input.Replace("\"", ""));
            var output = 0;

            foreach (var i in a)
            {
                output += Int32.Parse(i.ToString());
            }

            JObject output_obj = new JObject();
            output_obj["result"] = output;
            return output_obj.ToString();
        }

        public static string assignment(string input)
        {
            dynamic a = JObject.Parse(input.Replace("\"", ""));
            //dynamic a = JObject.Parse("{'argument1':'123','argument2':'A123','argument3':'Active',}");

            JObject output_obj = new JObject();
            foreach (var i in a)
            {
                output_obj[i.Name] = i.Value;
            }
            return output_obj.ToString();
        }

        public static string sub(string input)
        {
            JArray a = JArray.Parse(input.Replace("\"", ""));
            List<int> lst = a.ToObject<List<int>>();

            var output = lst[0] - lst[1];

            JObject output_obj = new JObject();
            output_obj["result"] = output;
            return output_obj.ToString();
        }

        public static string mul(string input)
        {
            dynamic a = JArray.Parse(input.Replace("\"", ""));
            var output = 1;

            foreach (var i in a)
            {
                output *= Int32.Parse(i.ToString());
            }

            JObject output_obj = new JObject();
            output_obj["result"] = output;
            return output_obj.ToString();
        }

        public static string div(string input)
        {
            JArray a = JArray.Parse(input.Replace("\"", ""));
            List<int> lst = a.ToObject<List<int>>();

            var output = lst[0]/lst[1];

            JObject output_obj = new JObject();
            output_obj["result"] = output;
            return output_obj.ToString();
        }

        public static string max(string input)
        {
            List<dynamic> input_data = JsonConvert.DeserializeObject<List<dynamic>>(input);
            dynamic output = input_data.Max();
            JObject output_obj = new JObject();
            output_obj["output"] = output;
            return output_obj.ToString();
        }

        public static string min(string input)
        {
            List<dynamic> input_data = JsonConvert.DeserializeObject<List<dynamic>>(input);
            dynamic output = input_data.Min();
            JObject output_obj = new JObject();
            output_obj["output"] = output;
            return output_obj.ToString();
        }

        public static string substr(string input)
        {
            List<dynamic> input_data = JsonConvert.DeserializeObject<List<dynamic>>(input);
            JObject output_obj = new JObject();
            string inputstring = input_data[0].ToString();
            if (input_data.Count == 2)
                output_obj["output"] = inputstring.Substring(Int32.Parse(input_data[1].ToString()));
            else
                output_obj["output"] = inputstring.Substring(Int32.Parse(input_data[1].ToString()), Int32.Parse(input_data[2].ToString()));
            return output_obj.ToString();
        }

        public static string concat(string input)
        {
            List<dynamic> input_data = JsonConvert.DeserializeObject<List<dynamic>>(input);
            dynamic output = input_data.Aggregate((acc, x) => acc + x);
            JObject output_obj = new JObject();
            output_obj["output"] = output;
            return output_obj.ToString();
        }

        public static string adddays(string input)
        {
            JArray a = JArray.Parse(input.Replace("\"", ""));
            //List<string> input_data = input.Split(',').ToList();
            List<string> input_data = a.ToObject<List<string>>();

            DateTime datetime = DateTime.Parse(input_data[0]).AddDays(Int32.Parse(input_data[1]));

            JObject output_obj = new JObject();
            output_obj["result"] = datetime.ToString("yyyy-MM-dd HH:mm:ss");
            return output_obj.ToString();
        }
    }
}