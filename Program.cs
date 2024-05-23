using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;


string apiUrl = "https://www.boredapi.com/api/activity/";


using (HttpClient client = new HttpClient())
{
    try
    {

        HttpResponseMessage response = await client.GetAsync(apiUrl);


        if (response.IsSuccessStatusCode)
        {

            string responseBody = await response.Content.ReadAsStringAsync();

            boredapi contents = JsonSerializer.Deserialize<boredapi>(responseBody);

            Console.WriteLine($"atividade: {contents.activity}");
            Console.WriteLine($"type: {contents.type}");
            Console.WriteLine($"participants: {contents.participants}");
            Console.WriteLine($"atividade: {contents.price}");
            Console.WriteLine($"atividade: {contents.link}");
            Console.WriteLine($"atividade: {contents.key}");
            Console.WriteLine($"atividade: {contents.accessibility}");

        }
        else
        {
            Console.WriteLine($"Failed to fetch data from the API. Status code: {response.StatusCode}");
        }
    }
    catch (HttpRequestException ex)
    {
        Console.WriteLine($"An error occurred while making the request: {ex.Message}");
    }
}


public class boredapi
{
    public string activity { get; set; }
    public string type { get; set; }
    public int participants { get; set; }
    public float price { get; set; }
    public string link { get; set; }
    public string key { get; set; }
    public float accessibility { get; set; }
}