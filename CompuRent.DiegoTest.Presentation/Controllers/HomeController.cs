namespace CompuRent.DiegoTest.Presentation.Controllers
{
    using CompuRent.DiegoTest.Presentation.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    /// <summary>
    /// Home Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class HomeController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Index View</returns>
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Privacies this instance.
        /// </summary>
        /// <returns>Privacy View</returns>
        public IActionResult Privacy()
        {
            return this.View();
        }

        /// <summary>
        /// Errors this instance.
        /// </summary>
        /// <returns>Error View</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
