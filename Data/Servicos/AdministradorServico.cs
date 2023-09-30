
using System.Text;
using System.Text.Json;
using blazor_view_dotnet7.Ambientes;
using blazor_view_dotnet7.Data.DTOs;
using blazor_view_dotnet7.Data.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;


namespace blazor_view_dotnet7.Data.Servicos;

public class AdministradorServico
{
    
    private HttpClient http = new HttpClient();

    public async Task<Administrador?> LoginAsync(LoginDTO login)
    {
      var content = new StringContent(JsonSerializer.Serialize(login), Encoding.UTF8, "application/json");
      var response =  await http.PostAsync($"{Configuracao.Host}/login", content);
      
      //se o  (StatusCode) vier diferente de (ok ou seja 200) eu (retorno nullo)
      if (response.StatusCode != System.Net.HttpStatusCode.OK) return null;

      //se ele vier (ok) eu tenho o meu objeto e aí farei o (decerealize) dele.
      // leio o conteudo (ReadAsStringAsync) e faço o (Deserializer)
      var result = await response.Content.ReadAsStringAsync();
      //pego o (result) desta leitura e faço o (Deserialize)
      var administrador = JsonSerializer.Deserialize<Administrador>(result, new JsonSerializerOptions
      {
          PropertyNameCaseInsensitive = true
      });

           return administrador;
    }


    //se o token vier vazio eu vou fazer o redirect para tela de login
     public static async Task RedirectLoginSeNaoLogado(ProtectedLocalStorage browserStorage, NavigationManager navManager)
    {
      //caso token vier vazio eu vou fazer o redirect para tela de login
        var token = await GetToken(browserStorage);
        if(string.IsNullOrEmpty(token))
        {
           navManager.NavigateTo("/login");
        }
    }

    //Buscando o token
    //colocando static eu não crio instância
    public static async Task<string> GetToken(ProtectedLocalStorage BrowserStorage)
    {
      //estou fazendo um (GetAsync) desta forma eu pego o objeto (logado)
      //faço a tipagem no meu string (GetAsync<string>)
      //o (GetAsync<string> é para pegar o meu objeto("admLogado"); no localStorage)
      var json = await BrowserStorage.GetAsync<string>("admLogado");
      //programação defensiva
      if(json.Value is null) return "";
      //depois que eu pego a informação eu preciso desparciar.
      var adm  = JsonSerializer.Deserialize<Administrador>(json.Value, new JsonSerializerOptions
       {
          PropertyNameCaseInsensitive = true
       });
       //dando certo eu retorno o token se não (??) eu retorno vazio.
       return adm?.Token ?? "";
    }
   
}
  

