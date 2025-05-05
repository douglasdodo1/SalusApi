public class CepViaService {
    private readonly HttpClient _httpClient;
    public CepViaService(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public async Task<ViaCepModel> Consult(String cep) {
        cep = cep.Replace("-", "").Trim();
        return null;
    }
}