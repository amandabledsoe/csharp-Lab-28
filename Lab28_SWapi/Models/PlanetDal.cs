using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lab28_SWapi.Models
{
    public class PlanetDal
    {
        public string GetAPIJson(string endpoint, int id) 
        {
            string url = $"https://swapi.dev/api/{endpoint}/{id}/";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());
            string output = sr.ReadToEnd();
            return output;
        }

        public Planet GetPlanet(string endpoint, int id)
        {
            string planetData = GetAPIJson(endpoint, id);
            Planet pl = JsonConvert.DeserializeObject<Planet>(planetData);
            return pl;
        }
        //now, need to go use these items in a view through our controller! 
        //since our instructions want us to use both models on the Index page, I'm going to put everything in the
        //home controller.
    }
}
