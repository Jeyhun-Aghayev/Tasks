using Microsoft.AspNetCore.Mvc;

namespace Cookie_.Controllers;

public class HomeController : Controller
{
    private readonly string COOKIE_NAME = "Survey";
    public IActionResult Index()
    {
        var cookie = Request.Cookies[COOKIE_NAME];
        return View(model: cookie, viewName: nameof(Index));// viewName is optional
    }


    [HttpPost]
    public IActionResult Index(string survey)
    {
        CookieOptions options = new()
        {
            //Expires = DateTime.Now.AddDays(1)  // 1 günlük bir cookie oluşturduk
            //Expires = DateTime.Now.AddMinutes(1),  // 1 dakikalık bir cookie oluşturduk
            Expires = DateTime.Now.AddSeconds(10),  // 10 saniyelik bir cookie oluşturduk  
        };

        Response.Cookies.Append(COOKIE_NAME, survey, options);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult CLear()
    {
        Response.Cookies.Append(COOKIE_NAME, "", new()
        {
            Expires = DateTime.Now.AddDays(-1)
        });
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete()
    {
        Response.Cookies.Delete(COOKIE_NAME);
        return RedirectToAction(nameof(Index));
    }
}
