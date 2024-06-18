
using Microsoft.EntityFrameworkCore;
using testePratico.Data;
using testePratico.Repositories;
using testePratico.Repositories.Interface;

namespace testePratico
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //configurando o banco
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<UserDbContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            //toda vez que chamar essa interface ele vai instanciar essa classe usuario repositorio.
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

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
