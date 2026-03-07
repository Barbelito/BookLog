using Application.Extensions;
using Application.Users.Abstractions;
using Application.Users.Factories;
using Infrastructure.Extensions;
using Infrastructure.Persistence.EFC.Contexts;
using Presentation.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddValidation();
builder.Services.AddApplication(builder.Configuration, builder.Environment);

builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    await dataContext.Database.EnsureCreatedAsync();
}

app.MapOpenApi();
app.UseHttpsRedirection();

app.MapPost("/api/users", async (RegisterUserRequest req, IUserService service, CancellationToken ct = default) =>
{
    var dto = UserFactory.Create(req.FirstName, req.LastName, req.Username, req.Email);
    var result = await service.RegisterUserAsync(dto, ct);
    return result.IsSuccess
        ? Results.Created($"/api/users/{result.Value!.Id}", result.Value)
        : Results.Problem(result.Error.Message, statusCode: result.Error.HttpStatus);
});


app.Run();
