using Backend.DTOs;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace Backend.Services
{
    public class PostService:IPostsService
    {
       private HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PostDTO>> Get()
        {
      
            var result = await _httpClient.GetAsync(_httpClient.BaseAddress);
            var body = await result.Content.ReadAsStringAsync();

            //Con esta variable los strings entran en Mayusculas como no, asi devuelve el valor neto.
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var post = JsonSerializer.Deserialize<IEnumerable<PostDTO>>(body, options);

            return post;
        }
    }
}
