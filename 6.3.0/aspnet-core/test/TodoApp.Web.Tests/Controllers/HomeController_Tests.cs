using System.Threading.Tasks;
using TodoApp.Models.TokenAuth;
using TodoApp.Web.Controllers;
using Shouldly;
using Xunit;

namespace TodoApp.Web.Tests.Controllers
{
    public class HomeController_Tests: TodoAppWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}