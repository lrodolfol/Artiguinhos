using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddFeatureManagement();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapGet("/api/cadastro", async (IFeatureManager featureManager) =>
{
    var list = featureManager.GetFeatureNamesAsync();


    if (await featureManager.IsEnabledAsync("RegistroNaNuvem"))
    {
        return "Cadastrado com sucesso na nuvem";
    }
    else
    {
        return "Cadastrado com sucesso no servidor local";
    }    
})
.WithName("cadastro");

app.Run();
