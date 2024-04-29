using Library.BLL.Services.BookBorrows;
using Library.BLL.Services.Books;
using Library.BLL.Services.Users;
using Library.DAL.Repositories.Authors;
using Library.DAL.Repositories.BookBorrows;
using Library.DAL.Repositories.Books;
using Library.DAL.Repositories.Contracts;
using Library.DAL.Repositories.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBookBorrowRepository, BookBorrowRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookBorrowService, BookBorrowService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
