using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add dependency for in memory
builder.Services.AddDbContext<MovieContext>(options =>
options.UseInMemoryDatabase("MovieList"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/*var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};*/

app.MapGet("/movies/complete", async (MovieContext mc) =>
    await mc.Movies.ToListAsync());
app.MapGet("/movies/{id}", async (int id, MovieContext mc) =>
    await mc.Movies.FindAsync(id));
app.MapPost("/movies", async (Movie m, MovieContext mc) =>
{
    mc.Movies.Add(m);
    await mc.SaveChangesAsync();
});


app.MapPut("/movie/{id}", async (int id, Movie m, MovieContext mc) =>
{
    var ids = await mc.Movies.FindAsync(id);
    if (ids is null) return Results.NotFound();
    ids.Name = m.Name;
    //ids.price = p.price;
    await mc.SaveChangesAsync();
    return Results.NoContent();

});

app.MapDelete("/movie/{id}", async (int id, MovieContext mc) =>
{
    if (await mc.Movies.FindAsync(id) is Movie m)
    {
        mc.Movies.Remove(m);
        await mc.SaveChangesAsync();
        return Results.Ok(m);
    }
    return Results.NotFound();
});

app.Run();

class Movie
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class MovieContext : DbContext
{
    public MovieContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Movie> Movies { get; set;}
}