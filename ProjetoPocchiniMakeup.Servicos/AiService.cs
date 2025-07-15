using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using ProjetoPocchiniMakeup.Servicos.Interfaces;

public class AiService : IAiService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;
    public AiService(IConfiguration config)
    {
        _httpClient = new HttpClient();
        _config = config;
    }
    public async Task<string> GetAiResponseAsync(string prompt)
    {
        var url = _config["GitHubModels:ApiUrl"];
        var token = _config["GitHubModels:Token"];
        _httpClient.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", token);
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("ProjetoPocchiniMakeup");

        var requestBody = new
        {
            model = "mistralai/mistral-7b-instruct",
            messages = new[]
            {
                new { role = "user", content = prompt }
            },
            mar_tokens = 100
        };
        var content = new StringContent(
        JsonSerializer.Serialize(requestBody),
        Encoding.UTF8,
        "application/json"
        );

        var response = await _httpClient.PostAsync(url, content);
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            return $"Erro: {response.StatusCode} - {error}";
        }
        var result = await response.Content.ReadAsStringAsync();
        return result;
    }
}
