using Microsoft.AspNetCore.Mvc;

namespace HelloController.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post' >" +
                "<input type='text' name='name' />" +
                "<select name='language'><option selected value = 'Eng' >English</ option >" +
                "<option value = 'Fr'> French</ option >" +
                "<option value = 'It' > Italy </ option >" +
                "<option value = 'Ge'> German </ option >" +
                "<option value = 'Hi'> Hindi </ option >" +
                "</select>" +
                "<input type=submit value='Greet me!' />" +
                "</form>";
            //return View();
            return Content(html, "text/html");
        }
        [Route("/")]
        [HttpPost]
        public IActionResult Display(string name,string language)
        {
            string finalmsg = "";
            if (language.Equals("Eng"))
            {
                finalmsg = string.Format(string.Format("<h1>Hello {0}</h1>", name));
            }
            if (language.Equals("Fr"))
            {
                finalmsg = string.Format(string.Format("<h1>Bonjour {0}</h1>", name));
            }
            if (language.Equals("It"))
            {
                finalmsg = string.Format(string.Format("<h1>CIAO {0}</h1>", name));
            }
            if (language.Equals("Ge"))
            {
                finalmsg = string.Format(string.Format("<h1>GUTEN TAG {0}</h1>", name));
            }
            if (language.Equals("Hi"))
            {
                finalmsg = string.Format(string.Format("<h1>Namaste {0}</h1>", name));
            }


            return Content(finalmsg, "text/html");
            
        }

        

        
    }
}
