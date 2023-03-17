using WEBAPI_order_ticket.Models;
using WEBAPI_order_ticket.Repositories.CastRepository;
using WEBAPI_order_ticket.Repositories.GenreRepository;
using WEBAPI_order_ticket.Repositories.MovieRepository;
using WEBAPI_order_ticket.Repositories.UserRepository;

namespace WEBAPI_order_ticket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //----------------------------Add Scope---------------------------------//
            builder.Services.AddScoped<OrderTicketContext>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddScoped<ICastRepository, CastRepository>();

            //----------------------------------------------------------------------//

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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}