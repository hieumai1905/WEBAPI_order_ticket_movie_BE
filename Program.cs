using WEBAPI_order_ticket.Models;
using WEBAPI_order_ticket.Repositories.CastRepository;
using WEBAPI_order_ticket.Repositories.CinemaRepository;
using WEBAPI_order_ticket.Repositories.GenreRepository;
using WEBAPI_order_ticket.Repositories.InvoicesRepository;
using WEBAPI_order_ticket.Repositories.MovieRepository;
using WEBAPI_order_ticket.Repositories.RoomRepository;
using WEBAPI_order_ticket.Repositories.SchedulesRepository;
using WEBAPI_order_ticket.Repositories.SeatRepository;
using WEBAPI_order_ticket.Repositories.TicketRepository;
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
            builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
            builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            builder.Services.AddScoped<ITicketRepository, TicketRepository>();
            builder.Services.AddScoped<ISeatRepository, SeatRepository>();
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