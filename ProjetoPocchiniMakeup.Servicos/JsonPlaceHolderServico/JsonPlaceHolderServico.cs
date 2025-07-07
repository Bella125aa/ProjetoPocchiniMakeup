using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ProjetoPocchiniMakeup.Dominio.Entidade;
using ProjetoPocchiniMakeup.Servicos.Interfaces;
using ProjetoPocchiniMakeup.Servicos.JsonPlaceHolderServico.Models;

public class JsonPlaceHolderServico : IJsonPlaceHolderServico
{
    private readonly HttpClient _httpClient;

    public JsonPlaceHolderServico()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
    }

    public async Task<List<servicoNoiva>> ListarServicos()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("todos");
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        var todo = JsonConvert.DeserializeObject<List<Todo>>(responseBody);

        var servicos = new List<servicoNoiva>();

        return servicos;
    }
}