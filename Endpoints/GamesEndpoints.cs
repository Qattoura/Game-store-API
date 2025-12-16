using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints
{
    public static class GamesEndpoints
    {
        const string GetGameEndPointName = "GetGame";


        public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app) {

            var group = app.MapGroup("games").WithParameterValidation();

            // GET /games
            group.MapGet("/", async (GameStoreContext dbContext) => 
            await dbContext.Games
                .Include(game => game.Genre)
                .Select(game => game.ToGameSummaryDto())
                .AsNoTracking()
                .ToListAsync()

            );

            // GET /games/x
            group.MapGet("/{id}", async (int id, GameStoreContext dbContext) => {

                 Game? game = await dbContext.Games.FindAsync(id);
                  

                return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());

            }).WithName(GetGameEndPointName);

            // Post /game

            group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
            {
                Game game = newGame.ToEntity();
                //game.Genre = dbContext.Genres.Find(newGame.GenreId);


                dbContext.Games.Add(game);
                dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game.ToGameDetailsDto());
            }
            );

            // Put /game

            group.MapPut("/{id}", async (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
            {
                //var index = games.FindIndex(game => game.Id == id);
                var existingGame = await dbContext.Games.FindAsync(id);

                if (existingGame is null)
                {
                    return Results.NotFound();
                }

                dbContext.Entry(existingGame).CurrentValues
                            .SetValues(updatedGame.ToEntity(id));
                dbContext.SaveChangesAsync();

                return Results.NoContent();
            });

            // Delete /games/x

            group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) => 
            {

                await dbContext.Games.Where(game => game.Id == id)
                    .ExecuteDeleteAsync();

                return Results.NoContent();

            });


            return group;

        }

    }
}
