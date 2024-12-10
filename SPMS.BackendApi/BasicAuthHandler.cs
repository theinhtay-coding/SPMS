using System.Text;

namespace SPMS.BackendApi;

public class BasicAuthHandler
{
    private readonly RequestDelegate next;

    public BasicAuthHandler(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            //context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            ////context.Response.StatusCode = 401;
            //await context.Response.WriteAsync("Unauthorized");
            await RespondUnauthorized(context, "Missing Authorization Header");
            return;
        }

        // Basic userid:password
        var header = context.Request.Headers["Authorization"].ToString();
        var encodeCreds = header.Substring(6);
        var creds = Encoding.UTF8.GetString(Convert.FromBase64String(encodeCreds));
        string[] uidpwd = creds.Split(':',2);

        if (uidpwd.Length != 2)
        {
            await RespondUnauthorized(context, "Invalid Authorization Header Format");
            return;
        }

        var uid = uidpwd[0];
        var password = uidpwd[1];

        if(uid != "admin" || password != "123456")
        {
            await RespondUnauthorized(context, "Invalid Username or Password");
            return;
        }
        await next(context);
    }

    private static async Task RespondUnauthorized(HttpContext context, string message)
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        context.Response.Headers["WWW-Authenticate"] = "Basic realm=\"MyApp\"";
        await context.Response.WriteAsync(message);
    }
}
