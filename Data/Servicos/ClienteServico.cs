using blazor_view_dotnet7.Ambientes;
using blazor_view_dotnet7.Data.Models;

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
    public async Task<Cliente[]?> Todos()
    {
      return await http.GetFromJsonAsync<Cliente[]>($"{Configuracao.Host}/clientes");      
    }

    public async Task<Cliente?> BuscarPorId(int id)
    {
      return await http.GetFromJsonAsync<Cliente?>($"{Configuracao.Host}/clientes/{id}");      
    }

    public async Task Incluir(Cliente cliente)
    {
      await http.PostAsJsonAsync<Cliente>($"{Configuracao.Host}/clientes", cliente);      
    }

    public async Task Atualizar(Cliente cliente)
    {
      //neste momento não estou passando retorno pois não preciso trabalhar com este objeto.
      //passo o /Id
      await http.PutAsJsonAsync<Cliente>($"{Configuracao.Host}/clientes/{cliente.Id}", cliente);      
    }

    public async Task Excluir(Cliente cliente)
    {
       await http.DeleteAsync($"{Configuracao.Host}/clientes/{cliente.Id}");
    }
  }
  

