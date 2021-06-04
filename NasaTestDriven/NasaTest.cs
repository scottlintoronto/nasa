using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Net;

namespace NasaTestDriven
{
    [TestClass]
    public class NasaTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string port = "52271";
            var client = new WebClient();
            client.Headers.Add("user-agent", "");
            var response = client.DownloadString(string.Format("http://localhost:{0}/nasa/api_key=bMb7A3YzVc8sRnQ72RzLwUiUSB6fSNTb1gPhfplx&date=2020-06-04", port));
            var returnPacket = JArray.Parse(response);
            Assert.Equals(returnPacket["explanation"], "On May 26, the Full Flower Moon was caught in this single exposure as it emerged from Earth's shadow and morning twilight began to wash over the western sky. Posing close to the horizon near the end of totality, an eclipsed lunar disk is framed against bare oak trees at Pinnacles National Park in central California. The Earth's shadow isn't completely dark though. Faintly suffused with sunlight scattered by the atmosphere, the inner shadow gives the totally eclipsed moon a reddened appearance and the very dramatic popular moniker of a Blood Moon. Still, the monstrous visage of a gnarled tree in silhouette made this view of a total lunar eclipse even scarier.");
            Assert.Equals(returnPacket["date"], "2021 - 06 - 04");
            Assert.Equals(returnPacket["url"], "https://apod.nasa.gov/apod/image/2106/Lunareclipse_PinnaclesNationalPark1024.jpg");
        }
    }
}