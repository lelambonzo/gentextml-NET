using OpenAI;

public class TextGenerationService
{
    private OpenAIApi openAiApi;

    public TextGenerationService(string apiKey)
    {
        openAiApi = new OpenAIApi(apiKey);
    }

    public async Task<string> GenerateText(string prompt)
    {
        var response = await openAiApi.CompleteText(prompt, temperature: 0.7, maxTokens: 100);

        if (response.IsSuccessStatusCode)
        {
            var generatedText = response.Content?.Choices?.FirstOrDefault()?.Text;
            return generatedText;
        }

        return null;
    }
}
