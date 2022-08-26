using Agenda.API.Configuration;
using Agenda.Application.Filters;
using Agenda.Application.Mappers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services, builder.Configuration);
ConfigureSwagger(builder.Services);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
ConfigureMiddleware(app , app.Services);
ConfigureEndpoints(app, app.Services);
app.Run();


void ConfigureServices(IServiceCollection services, ConfigurationManager configuration){
     services.AddControllers(opts =>
    {
        opts.Filters.Add(new ApplicationExceptionFilter());
    });
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddDependencyInjection();
    services.AddAutoMapper(typeof(DomainToResponseProfile), typeof(RequestToDomainProfile));
}


void ConfigureSwagger(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();

    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Agenda.API", Version = "v1" });

        // configura autenticação via swagger
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                                Digite 'Bearer' [espaço] e o token de login.
                                \r\n\r\nExemplo: 'Bearer 12345abcdef'",

            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,

                },
                new List<string>()
            }
        });

        // inclui comentários no swagger
        // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        // c.IncludeXmlComments(xmlPath);
    });
}

void ConfigureMiddleware(WebApplication app, IServiceProvider services)
{
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
    app.UseAuthentication();
    //app.UseAuthorization();
}

void ConfigureEndpoints(IEndpointRouteBuilder app, IServiceProvider services)
{
    app.MapControllers();
}