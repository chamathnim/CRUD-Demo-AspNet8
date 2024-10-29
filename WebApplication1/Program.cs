using System;
using System.Net.Mime;
using System.Text;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", (HttpContext context) =>
            {
                WriteHtml(context, @"
                                <!doctype html>
                                <html>
                                    <head><title>miniHTML</title></head>
                                    <body>
                                        <h1>Simple Framework</h1>
                                        <br/>
                                        <form action=""/login"" method=""post"">
                                            <label for=""username"">User name:</label>
                                            <input type=""text"" id=""username"" name=""username""
                                            <label for=""password"" >Password: </label>
                                            <input type=""password"" id=""password"" name=""password"" required>
                                            <button type=""submit""> Login </button>
                                        </form>
                                    </body>
                                </html>");
            });

            app.MapPost("/login", (HttpContext context) =>
            {
                var username = context.Request.Form["username"];
                var password = context.Request.Form["password"];

                if (username == "chama" && password == "123")
                {

                    var html = @"<!doctype html>
                            < html >
                            <head><title>miniHTML</title></head>
                            <body>
                            <h1> Simple Framework </h1>
                            <br/>
                            Welcome to our simple framework!
                            </body>
                            </html>";
                    WriteHtml(context, html);
                }
                else
                {
                    var html = @"
                                <!doctype html>
                                <html>
                                    <head><title>miniHTML</title></head>
                                    <body>
                                        <h1>Simple Framework</h1>
                                        <br/>
                                        <form action=""/login"" method=""post"">
                                            <label for=""username"">User name:</label>
                                            <input type=""text"" id=""username"" name=""username""
                                            <label for=""password"" >Password: </label>
                                            <input type=""password"" id=""password"" name=""password"" required>
                                            <button type=""submit""> Login </button>
                                            <br/>
                                            <label style=""color:red"">Login failed!</label> 
                                        </form>
                                    </body>
                                </html>";

                    WriteHtml(context, html);
                }
            });

            app.Run();
        }

        static void WriteHtml(HttpContext context, String html)
        {
            context.Response.ContentType = MediaTypeNames.Text.Html;
            context.Response.ContentLength = Encoding.UTF8.GetByteCount(html);
            context.Response.WriteAsync(html);
        }
    }
}
