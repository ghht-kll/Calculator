using Calculator.Services;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICalculatorService, CalculatorService>();

var app = builder.Build();

app.UseStatusCodePages();

app.UseExceptionHandler(app => app.Run(async context =>
{
    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
    var exception = exceptionHandlerPathFeature?.Error;

    context.Response.StatusCode = 500;
    await context.Response.WriteAsync($"Error 500. {exception?.Message}");
}));

app.MapGet("/", (IEnumerable<EndpointDataSource> endpointSources) 
    => string.Join("\n", endpointSources.SelectMany(source => source.Endpoints)));

app.MapGet("/Add/{a:double}/{b:double}", (double a, double b, ICalculatorService calculatorService) 
    => calculatorService?.Add(a, b));

app.MapGet("/Subtract/{a:double}/{b:double}", (double a, double b, ICalculatorService calculatorService) 
    => calculatorService?.Subtract(a, b));

app.MapGet("/Multiply/{a:double}/{b:double}", (double a, double b, ICalculatorService calculatorService) 
    => calculatorService?.Multiply(a, b));

app.MapGet("/Divide/{a:double}/{b:double}", (double a, double b, ICalculatorService calculatorService) 
    => calculatorService?.Divide(a, b));

app.Run();