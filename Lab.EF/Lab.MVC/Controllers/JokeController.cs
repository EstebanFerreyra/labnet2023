using Lab.MVC.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
    public class JokeController : Controller
    {
        // GET: Joke
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://v2.jokeapi.dev");
                client.DefaultRequestHeaders.Accept.Clear();

                HttpResponseMessage response = await client.GetAsync("/joke/Any");

                if (response.IsSuccessStatusCode)
                {
                    string jokeJson = await response.Content.ReadAsStringAsync();
                    Joke jokeResponse = JsonConvert.DeserializeObject<Joke>(jokeJson);
                    var joke = new Joke
                    {
                        category = jokeResponse.category,
                        type = jokeResponse.type,
                        setup = jokeResponse.setup,
                        delivery = jokeResponse.delivery
                    };
                    return View(joke);
                }
                else
                {
                    ViewBag.ErrorMessage = "No se pudo obtener el chiste.";
                    return View();
                }
            }
        }
    }
}