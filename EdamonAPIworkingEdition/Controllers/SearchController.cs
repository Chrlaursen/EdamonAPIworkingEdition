using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using EdamonAPIworkingEdition.Models;

namespace EdamaAPI.Controllers
{
    public class SearchController : Controller
    {
        //Hosted web API REST Service base url  
        string Baseurl = "https://api.edamam.com/";
        [HttpPost]
        public async Task<ActionResult> Index(string reportName)
        {
            List<Recipe> EmpInfo = new List<Recipe>();

            using (var client = new HttpClient())
            {
                string sea = reportName;
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("search?q=" + sea + "&app_id=a88093f8&app_key=4513de36c431f9936462ef4391f631e4&from=0&to=30&calories=gte%20591,%20lte%20722&health=alcohol-free");

                //Checking the response is successful or not which is sent using HttpClient  

                //Storing the response details recieved from web api   
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                var objResponse1 = JsonConvert.DeserializeObject<Rootobject>(EmpResponse);


                //returning the employee list to view  
                return View(objResponse1);
            }
        }
    }
}