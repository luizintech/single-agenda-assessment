using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SingleAgenda.Application.Dashboard;
using SingleAgenda.Dtos.Dashboard;
using System.Threading.Tasks;

namespace SingleAgenda.WebApi.Controllers
{
    [Authorize]
    [Route("api/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {

        [HttpGet]
        public async Task<DashboardStatisticsDto> Search(
            [FromServices] DashboardBusiness dashboardBusiness
        )
        {
            return await dashboardBusiness.ShowAsync();
        }

    }
}
