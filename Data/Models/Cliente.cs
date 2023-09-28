using System.ComponentModel.DataAnnotations;

namespace blazor_view_dotnet7.Data.Models;
/*
  Lembrando que esta (models struct cliente) é o (reflexo 
  da api models class Cliente.cs)
*/

//estou colocando a classe como struct para que seja a instância mais leve de um objeto
//(modelo ou classe) é sempre no singular.
public record Cliente 
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome não pode ser vazio")]
    [StringLength(50, ErrorMessage = "O nome esta muito extenso")]
    public string Nome { get; set; } = default!;

    //quando eu insiro o ? quero dizer que pode vir nullo.
    [Required(ErrorMessage = "O telefone não pode ser em branco")]
    public string Telefone {get; set;} = default!;
    //quando eu insiro o ? quero dizer que pode vir nullo.
    [Required(ErrorMessage = "O email não pode ser em branco")]
    public string Email { get; set; } = default!;

    public DateTime DataCriacao {get; set;}
}
