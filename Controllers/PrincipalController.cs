using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Session.Controllers
{
    public class PrincipalController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Tablero()
    {
        
        HttpContext.Session.SetInt32("Value", 0);
        return View();
    }

    public IActionResult ModifyValue(int modifier)
    {
        int currentValue = HttpContext.Session.GetInt32("Value") ?? 0;

        if (modifier == 1)
            currentValue += 1;
        else if (modifier == -1)
            currentValue -= 1;
        else if (modifier == 2)
            currentValue *= 2;
        else if (modifier == 0) // Random
            currentValue += new Random().Next(1, 11);

        HttpContext.Session.SetInt32("Value", currentValue);

        return RedirectToAction("Tablero");
    }

    public IActionResult CerrarSesion()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
}