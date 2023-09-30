using System.Net.Http.Headers;
using blazor_view_dotnet7.Ambientes;
using blazor_view_dotnet7.Data.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace blazor_view_dotnet7.Data.Servicos;

public class ClienteServico
{
    /*
       ao invês de eu passar o (HttpClient) em todos os métodos
       eu crio a instância e dou o nome (http) como referencia e passo nos métodos
       alem disto eu não preciso ficar criando (new) a todo momento.

       ficaria assim -> new HttpClient() em todo os métodos
       agora fica assim http.
    */
    private HttpClient http = new HttpClient();

    //estou retornando um array de cliente []
    //poderia tambem retornar uma Lista de cliente
    //Sem problemas lembando que o array é um pouco mais leve.
    //Os três darão certo <IEnumerable<Cliente>, <List<Cliente> ou <Cliente>[]
    //coloco o ? porque esta lista pode vir (nullable, nulo ou vazia)
    public async Task<Cliente[]?> Todos(string? token)
    {
      this.http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      return await http.GetFromJsonAsync<Cliente[]>($"{Configuracao.Host}/clientes");      
    }

    public async Task<Cliente?> BuscarPorId(int id, string? token)
    {
      this.http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      return await http.GetFromJsonAsync<Cliente?>($"{Configuracao.Host}/clientes/{id}");      
    }
     /*
       IMPORTANTISSIMO
       Eu poderia fazer conexão com (entity-framework ou dapper, SQL-ADO-connection) aqui no blazor
       ou seja me conectar a (base de dados) daqui mesmo através do blazor.
       Porque o (blazor) tem renderização via (server side e cliente side)

       *Com o blazor nos conseguimos (com react não com vuejs não com angular não, com o next tambem não)
       *Todos estes não tem integração com o C#
     */
    public async Task Incluir(Cliente cliente, string? token)
    {
      this.http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      await http.PostAsJsonAsync<Cliente>($"{Configuracao.Host}/clientes", cliente);      
    }

    public async Task Atualizar(Cliente cliente, string? token)
    {
      this.http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      //neste momento não estou passando retorno pois não preciso trabalhar com este objeto.
      //passo o /Id
      await http.PutAsJsonAsync<Cliente>($"{Configuracao.Host}/clientes/{cliente.Id}", cliente);      
    }

    public async Task Excluir(Cliente cliente, string? token)
    {
      this.http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
       await http.DeleteAsync($"{Configuracao.Host}/clientes/{cliente.Id}");
    }
  }
  

