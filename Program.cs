using GameStore.Api.Data;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

//var connString = "Data Source = GameStore.db";

var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();




app.MapGamesEndpoints();
app.MapGenresEndpoints();

await app.MigrationDbAsync();

app.Run();
