using Application.Configuration;
using Infrastructure.Configuration;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

try
{
    var builder = WebApplication.CreateBuilder( args );

    var connectionString = builder.Configuration.GetConnectionString( "MSSQLSpotlight" );
    builder.Services.AddDbContext<SpotlightDbContext>( options =>
    {
        options.UseSqlServer( connectionString );
    } );

    builder.Services
        .AddApplication()
        .AddInfrastructure();

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

}
catch ( Exception ex )
{
    Console.WriteLine( ex.Message );
    Console.WriteLine( "Сервер неожиданно завершил работу." );
}
finally
{
    Console.WriteLine( "Сервер отключается..." );
}