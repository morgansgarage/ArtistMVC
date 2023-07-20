using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ArtistMVC.ExternalAPIs;

public class ArtistApi
{
    public string GetDescription(string id)
    {
        var client = new RestClient($"https://spotify23.p.rapidapi.com/artist_overview/?id={id}");
        var request = new RestRequest();

        request.AddHeader("x-rapidapi-key", "[Your API Key Here]]");
        request.AddHeader("x-rapidapi-host", "spotify23.p.rapidapi.com");

        var response = client.Get(request);
        var jsonData = JObject.Parse(response.Content);

        return jsonData["data"]["artist"]["profile"]["biography"]["text"].ToString();
    }
}