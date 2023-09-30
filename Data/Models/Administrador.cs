using System.ComponentModel.DataAnnotations;

namespace blazor_view_dotnet7.Data.Models;
/*
  Lembrando que esta (models struct cliente) é o (reflexo 
  da api models class Cliente.cs)
*/

//estou colocando a classe como struct para que seja a instância mais leve de um objeto
//(modelo ou classe) é sempre no singular.
public record Administrador 
{
    public string Email { get; set; } = default!;

    public string Permissao { get; set; } = default!;

    public string Token { get; set; } = default!;

    
}
