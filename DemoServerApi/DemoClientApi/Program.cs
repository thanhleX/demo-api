using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        await CallApiAsync();
    }

    static async Task CallApiAsync()
    {
        using (var httpClient = new HttpClient())
        {
            var apiUrl = "https://localhost:7121/api/Values"; // Thay đổi URL API nếu cần
            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
        }
    }
}
