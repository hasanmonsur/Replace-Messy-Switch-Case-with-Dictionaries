using CaseDictonaryWebAPI.Contacts;
using CaseDictonaryWebAPI.Contexts;
using CaseDictonaryWebAPI.Models;
using CaseDictonaryWebAPI.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
}); 

// Register strategies
var strategies = new Dictionary<NotificationType, INotificationStrategy>
{
    [NotificationType.Email] = new EmailNotificationStrategy(),
    [NotificationType.SMS] = new SmsNotificationStrategy(),
    [NotificationType.Push] = new PushNotificationStrategy()
};

builder.Services.AddSingleton(new NotificationContext(strategies));

builder.Services.AddScoped<NotificationService>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll"); // Apply CORS policy

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
