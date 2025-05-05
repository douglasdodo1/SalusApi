using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("viacep")]
public class ViaCepController : ControllerBase {
    private readonly CepViaService _ViacepService;

    public ViaCepController(CepViaService cepService) {
        _ViacepService = cepService;
    }

    [HttpGet("{cep}")]
    public async Task<IActionResult> FindByCep(string cep) {
        var address = await _ViacepService.Consult();
        return new OkObjectResult(address);
    }
}