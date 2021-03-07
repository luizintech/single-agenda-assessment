using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SingleAgenda.Application.Contact;
using SingleAgenda.Dtos.Contact;
using SingleAgenda.Dtos.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleAgenda.WebApi.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController 
        : ControllerBase
    {

        //[Authorize]
        [HttpGet]
        public IEnumerable<PersonDto> Search(
            [FromServices] ContactBusiness contactBusiness
        )
        {
            return contactBusiness.ListAllAsync();
        }

        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] ContactBusiness contactBusiness)
        {
            return await contactBusiness.GetByIdAsync(id);
        }

        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<ResultDto>> CreateAsync(
            [FromBody] PersonDto person,
            [FromServices] ContactBusiness contactBusiness)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            return await contactBusiness.CreateAsync(person);
        }

        //[Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<ResultDto>> UpdateAsync(
            [FromRoute] int id,
            [FromBody] PersonDto person,
            [FromServices] ContactBusiness contactBusiness)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            person.Id = id;
            return await contactBusiness.UpdateAsync(person);
        }

        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultDto>> DeleteAsync(
            [FromRoute] int id,
            [FromServices] ContactBusiness contactBusiness)
        {
            return await contactBusiness.DeleteAsync(id);
        }

    }
}
