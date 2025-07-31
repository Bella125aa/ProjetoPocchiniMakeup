using Microsoft.Extensions.Configuration;
using OpenAI;
using OpenAI.Chat;
using System.ClientModel;
using ProjetoPocchiniMakeup.Servicos.Interfaces;

public class AiService : IAiService
{
    private readonly ChatClient _chatClient;

    public AiService(IConfiguration config)
    {
        var credential = config["GitHubModels:Token"];
        var endpoint = config["GitHubModels:ApiUrl"] ?? "https://models.github.ai/inference";
        var model = config["GitHubModels:Model"] ?? "openai/gpt-4o-mini";



        var options = new OpenAIClientOptions()
        {
            Endpoint = new Uri(endpoint)
        };

        _chatClient = new ChatClient(model, new ApiKeyCredential(credential), options);
    }

    public async Task<string> GetAiResponseAsync(string prompt)
    {
        var messages = new List<ChatMessage>
        {
           new SystemChatMessage("Você é uma assistente especializada apenas em maquiagem formal, casual, maquiagem de noiva, tons de pele e colorimetria. Recuse gentilmente qualquer pergunta fora desse escopo."),
           new UserChatMessage(prompt)
        };

        var requestOptions = new ChatCompletionOptions
        {
            Temperature = 0.7f,
            MaxOutputTokenCount = 1024
        };

        try
        {
            var response = await _chatClient.CompleteChatAsync(messages, requestOptions);
            return response.Value.Content[0].Text;
        }
        catch (Exception ex)
        {
            return $"Erro ao obter resposta da IA: {ex.Message}";
        }
    }
}
