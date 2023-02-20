using Microsoft.AspNetCore.Mvc;
using User_API.Domain;
using User_API.UserApi.Domain.DTOs;
using User_API.UserApi.Services;
using User_API.UserApi.Shared.Helpers;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//Task<ActionResult<NewUserResponseDTO>>

app.MapPost("/user", AddUser).WithName("AddUser");
app.MapGet("/user", GetUser).WithName("GetUser");

static async Task<IResult> AddUser([FromBody] NewUserDTO newUser, [FromServices] IUserService _userService)
{
    if (newUser == null || newUser.Email == null)
    {
        return Results.BadRequest();
    }

    var response = await _userService.AddUser(newUser);
    return Results.Ok(response);
}
static async Task<IResult> GetUser([FromRoute] string id, [FromServices] IUserService _userService)
{
    if (id == null) return Results.BadRequest();
    var response = await _userService.GetUserById(id);
    if (response == null) return Results.NotFound();
    return Results.Ok(response);
}



app.Run();
