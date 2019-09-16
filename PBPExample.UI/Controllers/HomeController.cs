using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PBPExample.UI.Interface;
using PBPExample.UI.Models;

namespace PBPExample.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPluginGenerator _pluginGenerator;
        public HomeController(IPluginGenerator pluginGenerator)
        {
            _pluginGenerator = pluginGenerator;
        }
        public IActionResult Index()
        {
            List<IPlugin> plugins = _pluginGenerator.GetPluginList();
            int sum = 0;
            foreach (var plugin in plugins)
            {
                sum += plugin.RuleCalculator(1);
            }
            return View(sum);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
