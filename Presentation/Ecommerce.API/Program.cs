using Ecommerce.Application;
using Ecommerce.Application.Validators.Products;
using Ecommerce.Infrastructure;
using Ecommerce.Infrastructure.Filters;
using Ecommerce.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

//The service that enables the HttpContext object created as a result of the request from the client to be accessed through the classes in the layers (business logic).
builder.Services.AddHttpContextAccessor();


//Browser-based structuring the cors policy used for security in requests
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod())); 


//fluentvalidation library and validators added
builder.Services.AddControllers(options=>options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(cfg=>cfg.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>()).ConfigureApiBehaviorOptions(options=>options.SuppressModelStateInvalidFilter=true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//jwtbearer authentication added with custom Admin schema
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer("Admin",options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateAudience = true, //Indicates for which recipient the JWT was created. -->www.blabla.com
        ValidateIssuer = true, //This field shows who created the JWT. --> www.api.com
        ValidateLifetime = true, //This field indicates when the JWT will become invalid.
        ValidateIssuerSigningKey = true, //This ensures that the JWT has not been modified and was created by the right person.

        //Related parameters are in appsettings.json
        ValidAudience = builder.Configuration["Token:Audience"],
        ValidIssuer = builder.Configuration["Token:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
        LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,  //It makes the JWT work second to second for its lifetime.

        NameClaimType = ClaimTypes.Name
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//Cors middleware
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
