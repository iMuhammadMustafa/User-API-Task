using User_API.UserApi.Shared.Helpers;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/user", () =>
{
    return "hello";
})
    .WithName("user");

app.MapGet("/user", () =>
{
    return "hello";
})
    .WithName("user");


app.Run();
