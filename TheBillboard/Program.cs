var builder = WebApplication.CreateBuilder(args);// in questa classe program viene creato WebApplication builder

// Add services to the container.
builder.Services.AddControllersWithViews();
//la seconda parte da riga 6 in poi è una pipeline dove per passare all'operazione successiva devi aver completato la precedente
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())//errore solo per i dev
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
                     // es1. faccio una chiamata su http://ires.it/logo.jpg
                     // es2 http://ires.it/about
app.UseHttpsRedirection(); // nel pipepline incotrna questo primo step che controllara che la chiamata sia fatta con https, rifa la chiamata ggiungendo la s quindi si passa al secondo step
                           //ES2 
app.UseStaticFiles();// ritorno il logo e blocco la pipeline perchè ho risolt
                     //ES2 non fa niente  

app.UseRouting();//ES2 controlla se l'url esiste, va avanti altriemente ritorna error es 404 

app.UseAuthorization();//ES2  per passare qui si deve mettere nel header autherizzationHeader, non è obbligatoria, qui finisce la pipeline, ogni riga si chiama middleware

app.MapControllerRoute( //ES2 qui mostra il risultato 
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
