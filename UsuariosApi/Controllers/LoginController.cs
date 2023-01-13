using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Requests;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private LoginService _loginService;

    public LoginController(LoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost]
    public IActionResult LogaUsuario(LoginRequest request)
    {
        var resultado = _loginService.LogaUsuario(request);
        if(resultado.IsFailed) return Unauthorized(resultado.Errors);
        return Ok(resultado.Successes);
    }

    [HttpPost("/solicita-reset")]
    public IActionResult SolicitaResetSenhaUsuario(SolicitaResetReuest request)
    {
        var resultado = _loginService.SolicitaResetSenhaUsuario(request);
        if(resultado.IsFailed) return Unauthorized(resultado.Errors);
        return Ok(resultado.Successes);
    }

    [HttpPost("/efetura-reset")]
    public IActionResult ResetaSenhaUsuario(EfetuaResetRequest request)
    {
        var resultado = _loginService.ResetaSenhaUsuario(request);
        if(resultado.IsFailed) return Unauthorized(resultado.Errors);
        return Ok(resultado.Successes);
    }

}