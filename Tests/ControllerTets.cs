using Xunit;
using WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Microsoft.Extensions.Options;
using WebApp.Config;

namespace UnitTests
{
    public class ControllerTest
    {
        private readonly IOptions<CustomConfig> _options;
        public ControllerTest()
        {
            _options = Options.Create(new CustomConfig() { VersionApp = "1" });
        }

        [Fact]
        public void about_page_shoud_show_correct_message()
        {
           

            HomeController controller = new HomeController(_options);

            ViewResult result = controller.About() as ViewResult;

            result.ViewData["Message"].Should().Be("Your application description page.");

        }

        [Fact]
        public void concat_page_shoud_show_correct_message()
        {
            HomeController controller = new HomeController(_options);

            ViewResult result = controller.Contact() as ViewResult;

            result.ViewData["Message"].Should().Be("Your contact page.");
        }

    }
}
