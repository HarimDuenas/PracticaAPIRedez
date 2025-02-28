using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text.Json;

namespace PracticaAPIRedez
{
    class Program
    {
        /*Emiliano Alejandro Santos Gonzalez y Harim Jesus Enrique Dueñas Davila que va :)*/
        static void Main(string[] args)
        {
            //METODO HTTP GET
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://valorant-api.com/v1/agents");
                var result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;

                Console.WriteLine(json);
            }

            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://jsonplaceholder.typicode.com/posts");
                var result = client.GetAsync(endpoint).Result;
                string responseBody = result.Content.ReadAsStringAsync().Result;

                var posts = JsonSerializer.Deserialize<List<Post>>(responseBody);

                foreach (var item in posts)
                {
                    Console.WriteLine(item.title + "\n");
                }
            }

            // METODO HTTP POST
            using (var client = new HttpClient())
            {
                String url = "https://jsonplaceholder.typicode.com/posts";

                Post post = new Post()
                {
                    userId = 50,
                    body = "Este es el body del post",
                    title = "Este es el titulo del post"
                };

                var data = JsonSerializer.Serialize<Post>(post);

                HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

                var httpResponse = client.PostAsync(url, content).Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;

                    var postResult = JsonSerializer.Deserialize<Post>(result);

                    Console.WriteLine(result);
                }
            }

        }
    }
}