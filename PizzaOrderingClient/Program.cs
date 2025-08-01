
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();
        Console.WriteLine("Enter pizza type: ");
        var type = Console.ReadLine();

        var response = await client.GetAsync($"https://localhost:5001/api/pizza/{type}");
        var result = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"Response: {result}");
    }
}
