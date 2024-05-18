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

            using (JsonDocument doc = JsonDocument.Parse(responseBody))
            {

                JsonElement root = doc.RootElement;

                if (root.TryGetProperty("activity", out JsonElement ElementoAtividade))
                {
                    string atividade = ElementoAtividade.ToString();

                    Console.WriteLine("Response from API:");
                    Console.WriteLine(atividade);

                }

            }
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
