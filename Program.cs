var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// handler functions


// GET

app.MapGet("/", () => "Hello World!");

app.MapGet("/amazing", HelloAspNetCore.Handlers.MyName);
// take out the anaymous ?lambda? function piece, and just pass the abstracted function reference

app.MapGet("/hello", (string name) => $"hello {name}");
// where does the name var come from?? 
// A: from a query parameter!!
// example: localhost:8000/hello?name=grace => returns hello grace
// a '%' is a space!


app.MapGet("/customers/{id}", (int id) => 
    Results.Ok(new Customer("Grace", "Wilmac", 28)));
    // this will mreturn the 200 status code because i said so lol
// path parameter



app.MapGet("/orders/{id}", (int id, string option) => {
   return  $"Your order ID: {id} has this options: {option}";

    });

// combine query parameter and path parameter 

// POST METHODS

app.MapPost("/customers", (Customer c) =>  
$"i will create a customer {c.Name} for you");
// how can we test? RestClient!


app.MapGet("/iamhappy", () => Results.Ok());
app.MapGet("/iamunhappy", () => Results.BadRequest());
app.MapGet("/iamunhappyandwilltelluwhy", () => Results.BadRequest("because it's friday"));



app.Run();



record Customer(string Name, string Company, int Age);
// this is like making a class
// if in program cs file, records have to be at the end of the file.
// when the app gets bigger, we would move these out into their own file.

