namespace RetendoVoice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            WebApplication app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseCors(options =>
            {
                options.AllowAnyHeader()
                       .AllowAnyMethod()
                       .SetIsOriginAllowed(origin => true) // Allow any origin
                       .AllowCredentials(); // Allow credentials (e.g., cookies)
            });

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}