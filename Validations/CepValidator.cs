using System.Text.Json;

public class CepValidator {
    private readonly HttpClient _httpClient;

    public CepValidator(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public async Task<Boolean> IsValid(string cep) {
        cep = cep.Replace("-", "").Trim();

        string url = $"https://viacep.com.br/ws/{cep}/json/";
        HttpResponseMessage response = await _httpClient.GetAsync(url);

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<CepModel>(content);

        if (result == null || result.Erro)
            return false;

        return true;
    }
}
