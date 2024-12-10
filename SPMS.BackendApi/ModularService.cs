using Microsoft.EntityFrameworkCore;

namespace SPMS.BackendApi;

public static class ModularService
{
    public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        return builder;
    }

    public static WebApplicationBuilder AddDbService(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(option =>
        {
            option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
        }, ServiceLifetime.Transient, ServiceLifetime.Transient);
        return builder;
    }

    public static WebApplicationBuilder AddDataAccessService(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DA_Student>();
        builder.Services.AddScoped<DA_AcademicYear>();
        builder.Services.AddScoped<DA_Grade>();
        builder.Services.AddScoped<DA_Promotion>();
        builder.Services.AddScoped<DA_Payment>();
        return builder;
    }

    public static WebApplicationBuilder AddBusinessLogicService(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<BL_Student>();
        builder.Services.AddScoped<BL_AcademicYear>();
        builder.Services.AddScoped<BL_Grade>();
        builder.Services.AddScoped<BL_Promotion>();
        builder.Services.AddScoped<BL_Payment>();
        return builder;
    }
}