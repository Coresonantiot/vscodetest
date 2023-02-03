using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HexTest.WebUI.DataAccessLayer;
using Newtonsoft.Json;

namespace HexTest.WebUI.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        
    }
    
    public IActionResult OnGetAutoCompleteData(string input, string condition)
    {
        ApiHandler ApiHandler = new ApiHandler();
        Dictionary<string, object> inputobject = JsonConvert.DeserializeObject<Dictionary<string, object>>(input);
        if (condition != "") condition = " and " + condition;
        var list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(ApiHandler.GetAll(inputobject["tablename"].ToString())).Where(item => item.ContainsKey(inputobject["fieldname"].ToString()) && item[inputobject["fieldname"].ToString()].ToString().Contains(inputobject["inputText"].ToString()));
        string json = JsonConvert.SerializeObject(list);
        return Content(json);
    }

    public IActionResult OnGetAutoFillEntityData(string input)
    {

        string json = "";
        ApiHandler ApiHandler = new ApiHandler();
        Dictionary<string, object>? inputobject = JsonConvert.DeserializeObject<Dictionary<string, object>>(input);
        if (inputobject.ContainsKey("inputText"))
        {
            var list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(ApiHandler.GetAll(inputobject["tablename"].ToString())).Where(item => item.ContainsKey(inputobject["fieldname"].ToString()) && item[inputobject["fieldname"].ToString()].ToString().Equals(inputobject["inputText"].ToString()));
            json = JsonConvert.SerializeObject(list);
        }
        else
        {
            var list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(ApiHandler.GetAll(inputobject["tablename"].ToString())).Where(item => item.ContainsKey(inputobject["fieldname"].ToString()));
            json = JsonConvert.SerializeObject(list);
        }
        return Content(json);

    }
}
