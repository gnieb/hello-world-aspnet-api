var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/ping", () => "pong");

app.MapGet("/hello", (string name) => $"hello {name}");
// where does the name var come from?? 
// A: from a query parameter!!
// example: localhost:8000/hello?name=grace


app.Run();


// hello world
