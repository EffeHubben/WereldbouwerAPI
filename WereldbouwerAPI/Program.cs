
using WereldbouwerAPI;

var builder = WebApplication.CreateBuilder(args);

//identity middleware = builder.Build();

// Add services to the container.
builder.Services.Configure<RouteOptions>(o => o.LowercaseUrls = true);

builder.Services.AddAuthorization();
builder.Services
    .AddIdentityApiEndpoints<IdentityUser>()
    .AddDapperStores(options => {
        options.ConnectionString = dbConnectionString;
});

//ar sqlConnectionString = builder.Configuration["SqlConnectionString"];
var sqlConnectionString = builder.Configuration.GetValue<string>("SqlConnectionString");
var sqlConnectionStringFound = !string.IsNullOrWhiteSpace(sqlConnectionString);


if (string.IsNullOrWhiteSpace(sqlConnectionString))
    throw new InvalidProgramException("Configuration variable SqlConnectionString not found");

builder.Services.AddTransient<IWereldBouwerRepository, WereldBouwerRepository>(o => new WereldBouwerRepository(sqlConnectionString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/", () => $"The API is up . Connection string found: {(sqlConnectionStringFound ? "" : "")}");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
