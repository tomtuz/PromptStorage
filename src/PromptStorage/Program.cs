using PromptStorage.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Prompt Storage API",
        Version = "v1",
        Description = "An API for storing and managing AI prompts."
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Register the IPromptStore service
var useDatabase = builder.Configuration.GetValue<bool>("UseDatabase");
if (useDatabase)
{
    // TODO: Implement and register database-backed prompt store
    throw new NotImplementedException("Database storage is not yet implemented.");
}
else
{
    builder.Services.AddSingleton<IPromptStore, InMemoryPromptStore>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction()) {
    app.UseHttpsRedirection();
}

// Add error handling middleware
app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
