using Microsoft.EntityFrameworkCore;
using UnluOnlineAkademi.Application.AboutUs.Queries.AboutUsList;
using UnluOnlineAkademi.Application.MailList.Queries.MailListList;
using UnluOnlineAkademi.Application.Mappings;
using UnluOnlineAkademi.Application.Policies.Queries.PoliciesList;
using UnluOnlineAkademi.Application.SSS.Queries.SSSList;
using UnluOnlineAkademi.Application.StudentTestimonial.Queries.StudentTestimonialList;
using UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsList;
using UnluOnlineAkademi.Domain.Interfaces;
using UnluOnlineAkademi.Persistence.Context;
using UnluOnlineAkademi.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAboutUsListQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetWhyUsListQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetStudentTestimonialListQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetSSSListQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetPoliciesListQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetMailListListQuery).Assembly));

builder.Services.AddControllers();
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
