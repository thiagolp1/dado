using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/Dado/d{numerodefaces}", 
( [FromRoute] int numerodefaces) => 
{  

    if(numerodefaces <= 0)
    {   
        return Results.BadRequest(new {Erro= "O dado tem que ter no minimo uma face"});

    }

int face = RandomNumberGenerator.GetInt32(1, numerodefaces + 1); 

return Results.Ok(new{dado = $"d{numerodefaces}", Rolagem = face}); 

} );

app.Run();