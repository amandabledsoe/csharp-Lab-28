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
    //third, create Data access layer classes for each model to use to call APIs
    public class PersonDal
    {
        //fourth, create a GetAPIString Method that will return a string of JSON
        public string GetAPIJson(string endpoint, int id)
        {
            //fifth, store the api call link in a string called url so you can use it to make a request and get a get a response
            string url = $"https://swapi.dev/api/{endpoint}{id}/";

            //sixth, using your url string, send a request and get a response to the api
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //seventh, read the response from the api call and output it as something we can use ... a string (of JSON!)
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string output = sr.ReadToEnd();
            return output;
        }

        //eighth, create a method that breaks down (deserializes) the JSON string we got and converts it into a person
        public Person GetPerson(string endpoint, int id)
        {
            //ninth, get the person's information by calling the API using the endpoint + persons Id and store it in a string (of JSON).
            string personData = GetAPIJson(endpoint, id);

            //tenth, deserialize the string (of JSON) and convert it into a a person that we can return and return that person.
            Person p = JsonConvert.DeserializeObject<Person>(personData);
            return p;
        }
        //now, do this all again for the other models (planet) in their own separate Data Access Layer!
    }
}
