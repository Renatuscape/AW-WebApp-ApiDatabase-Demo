using WebAppDb_Demo.Data;

namespace WebAppDb_Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add dependencies
            builder.Services.AddControllers(); //required for MapControllers
            builder.Services.AddDbContext<AlbumDbContext>();
            builder.Services.AddSwaggerGen(); //documentation with Swashbuckle
            //All services have to be added before Build
            var app = builder.Build();

            //Middleware
            app.UseSwagger(); //documentation with Swashbuckle
            app.UseSwaggerUI(); //documentation with Swashbuckle
            app.MapControllers(); //Required for controllers to work

            app.Run();
        }
    }
}
