
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;

namespace UsuariosApi.Services;

public class LoginService
{
    private SignInManager<CustomIdentityUser> _signInManager;
    private TokenService _tokenService;

    public LoginService(SignInManager<CustomIdentityUser> signInManager, 
        TokenService tokenService)
    {
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public Result LogaUsuario(LoginRequest request)
    {
        var resultadoIdentity = _signInManager
            .PasswordSignInAsync(request.Username, request.Password, false, false);
        if(resultadoIdentity.Result.Succeeded)
        {
            var identityUser = _signInManager.UserManager.Users
                .FirstOrDefault(usuario => 
                    usuario.NormalizedUserName == request.Username!.ToUpper());
            var token = _tokenService
                .CreateToken(identityUser!, _signInManager
                    .UserManager.GetRolesAsync(identityUser!).Result.FirstOrDefault());
            return Result.Ok().WithSuccess(token.Value);
        }
        return Result.Fail("Login Falhou");
    }

    public Result SolicitaResetSenhaUsuario(SolicitaResetReuest request)
    {
        var identityUser = RecuperaUsuarioPorEmail(request.Email!);
        if (identityUser != null)
        {
            var codigoReguperacao = _signInManager.UserManager
                .GeneratePasswordResetTokenAsync(identityUser).Result;
            return Result.Ok().WithSuccess(codigoReguperacao);
        }
        return Result.Fail("Falha ao solicitar redefinição");
    }

    public Result ResetaSenhaUsuario(EfetuaResetRequest request)
    {
        var identityUser = RecuperaUsuarioPorEmail(request.Email!);
        var resultadoIdentity = _signInManager.UserManager
            .ResetPasswordAsync(identityUser!, request.Token, 
                request.Password).Result;
        if(resultadoIdentity.Succeeded) return Result.Ok()
            .WithSuccess("Senha redefinida com sucesso!");
        return Result.Fail("Houve um erro na operação");
    }

    private CustomIdentityUser? RecuperaUsuarioPorEmail(string email)
    {
        return _signInManager.UserManager.Users
                .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
    }
}