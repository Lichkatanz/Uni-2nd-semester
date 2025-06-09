using System.Net.Http.Json;

public class ExternalApiService
{
    private readonly HttpClient _httpClient;

    public ExternalApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Movie> FetchMovieAsync(string apiUrl)
    {
        return await _httpClient.GetFromJsonAsync<Movie>(apiUrl);
    }
}
