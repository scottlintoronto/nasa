using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Nasa.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class NasaController : ControllerBase
    {
        const string url = "https://api.nasa.gov/planetary/apod?api_key=bMb7A3YzVc8sRnQ72RzLwUiUSB6fSNTb1gPhfplx";

        public class Planetary
        {
            public string copyright
            {
                get;
                set;
            }
            public string date
            {
                get;
                set;
            }
            public string explanation
            {
                get;
                set;
            }
            public string hdurl
            {
                get;
                set;
            }
            public string media_type
            {
                get;
                set;
            }
            public string service_version
            {
                get;
                set;
            }
            public string title
            {
                get;
                set;
            }
            public string url
            {
                get;
                set;
            }
        }

        [HttpGet]
        public string Get(string date)
        {
            string result = "";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            if (date != null)
            {
                httpRequest = (HttpWebRequest)WebRequest.Create(url + "&date=" + date.ToString());
            }
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            var planetaryObject = JsonConvert.DeserializeObject<Planetary>(result);
            //Create new object
            var jsondata = new
            {
                date = planetaryObject.date,
                explanation = "'" + planetaryObject.explanation + "'",
                url = "'" + planetaryObject.url + "'"
            };
            return jsondata.ToString();
        }
    }
}
