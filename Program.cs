using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using blazor_view_dotnet7.Data;
using blazor_view_dotnet7.Data.Servicos;
using blazor_view_dotnet7.Ambientes;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
/*
caso eu não queira utilizar o AddSingleton para fazer 
injeção de depêndencia @using Data.Servicos lá no index.razor
* eu posso utilizar a forma de criar instância lá no index.razor
seria (new ClienteServico()) e  instânciar o meu objeto
*/
builder.Services.AddSingleton<ClienteServico>();

//este builder.Configuration ira no meu appsettings e pegará 
//o meu nó HOST que eu criei
Configuracao.Host = builder.Configuration["Host"];

//este vindo o endereço da minha api ou host lá do meu
//appsettings.json = http://localhost:5131/
//Console.WriteLine(Configuracao.Host);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
