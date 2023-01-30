using P04Sklep.API.Services.ProductService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IProductService, ProductService>();  //obiekt jest tworzony za kazdymrazem dla nowego zapytania HTTP
 // od klienta - jedno zapytanie tworzny jedn¹ instancjê  

//builder.Services.AddTransient - obiekt jest tworzony za kazdym razem kiedy odwo³ujemy siê do konstruktora , nawet podczas 
 // trwania cyklu jednego zapytania 

//builder.Services.AddSingleton - nowa instancja klasy Procduct service zostanie utworzona tylko 1 raz na ca³y cykl trwania naszej aplikacji

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
