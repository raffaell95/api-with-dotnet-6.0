using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Requests;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CadastroController : ControllerBase
{
    private CadastroService _cadastroService;

    public CadastroController(CadastroService cadastroService)
    {
        _cadastroService = cadastroService;
    }

    [HttpPost]
    public IActionResult CadastrarUsuario(CreateUsuarioDto createDto)
    {
        var resultado = _cadastroService.CadastrarUsuario(createDto);
        if(resultado.IsFailed) return StatusCode(500);
        return Ok(resultado.Successes);
    }

    [HttpGet("/ativa")]
    public IActionResult AtivaContaUsuario([FromQuery] AtivaContaRequest request)
    {
        var resultado = _cadastroService.AtivaContaUsuario(request);
        if(resultado.IsFailed) return StatusCode(500);
        return Ok(resultado.Successes);
    }

}