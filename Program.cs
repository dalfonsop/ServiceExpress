using ServiceExpress.Application.Configurations;
using ServiceExpress.Application.Interfaces;
using ServiceExpress.Application.Services;
using ServiceExpress.Infrastructure.Interfaces;
using ServiceExpress.Infrastructure.Persistence;
using ServiceExpress.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Import Appsettings variables
// Carga desde appsettings.json o variables de entorno
builder.Services.Configure<WhatsAppWebHookSettings>(
    builder.Configuration.GetSection("WhatsAppWebHook")
);

//Dependency Injection
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IRegistroConversacionRepository, RegistroConversacionRepository>();
builder.Services.AddScoped<IWhatsAppWebHookService, WhatsAppWebHookService>();
builder.Services.AddScoped(typeof(IGenericDapperRepository<>), typeof(GenericDapperRepository<>));

var app = builder.Build();

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://0.0.0.0:{port}");


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });

//}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var verifyToken = "s3rvi3xpr3ss"; // igual que en tu variable verifyToken

app.MapGet("/webhook", (HttpRequest req) =>
{
    var mode = req.Query["hub.mode"];
    var token = req.Query["hub.verify_token"];
    var challenge = req.Query["hub.challenge"];

    if (mode == "subscribe" && token == verifyToken)
    {
        Console.WriteLine("WEBHOOK VERIFIED");
        return Results.Text(challenge, "text/plain");
    }

    return Results.StatusCode(403);
});

app.Run();
