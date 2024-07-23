using Application.Configuration;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder( args );

var connectionString = builder.Configuration.GetConnectionString( "MSSQLSpotlight" );
builder.Services.AddDbContext<SpotlightDbContext>( options =>
{
    options.UseSqlServer( connectionString );
} );

builder.Services.AddApplication();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
