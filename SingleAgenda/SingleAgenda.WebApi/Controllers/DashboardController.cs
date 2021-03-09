using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SingleAgenda.Application.Dashboard;
using SingleAgenda.Dtos.Contact;
using SingleAgenda.Dtos.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleAgenda.WebApi.Controllers
{
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
