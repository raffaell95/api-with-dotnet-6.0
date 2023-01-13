using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Requests;

public class SolicitaResetReuest
{
    [Required]
    public string? Email { get; set; }
}