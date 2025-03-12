using Graphql.ServiceQ.Db;
using Graphql.ServiceQ.Query;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PostgresDbContext>(
    options => options.UseNpgsql(builder.Configuration["ConnectionString"]));

builder.Services
    .AddRouting()
    .AddGraphQLCore()
    .AddGraphQLServer(disableDefaultSecurity: true)
    .AddQueryType<Query>()
    .AddSorting()
    .AddProjections()
    .AddFiltering();

var app = builder.Build();

app.UseRouting();
app.MapGraphQL();

app.Run();
