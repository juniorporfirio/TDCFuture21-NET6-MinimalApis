var builder = WebApplication.CreateBuilder(args);

//ConfigureServices

using var app = builder.Build();

//Configure

//Endpoints
var routeEndpoint = "/tdc/";

app.MapGet($"{routeEndpoint}inovation", () => "TDC Inovations 21!");
app.MapGet($"{routeEndpoint}connections", () => "TDC Connections 21!");
app.MapGet($"{routeEndpoint}transformation", () =>"TDC Transformation 21!");
app.MapGet($"{routeEndpoint}future", () => "TDC Future 21!");

await app.RunAsync();
