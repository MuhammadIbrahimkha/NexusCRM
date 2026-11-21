using NexusCRM.Api.ExceptionHandling;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers (class-based endpoints), OpenAPI document, standard ProblemDetails and our global error handler
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

app.UseExceptionHandler();   // must be first so it catches errors from everything after it
app.UseStatusCodePages();    // unknown routes and empty 4xx responses also use ProblemDetails

// Interactive API docs: open /scalar/v1 in the browser
app.MapOpenApi();
app.MapScalarApiReference();

app.MapControllers();        // finds every class that inherits ControllerBase and registers its routes

app.Run();

// Makes the Program class visible to the integration tests (WebApplicationFactory) on Day 6.
public partial class Program;
