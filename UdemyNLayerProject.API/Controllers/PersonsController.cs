using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> service;

        public PersonsController(IService<Person> service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await service.GetAllAsync();

            return Ok(persons);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Person person)//örnek old için entity aldık normalde clientdan dto dönmeli!!
        {
            var newPerson = await service.AddAsync(person);

            return Ok(newPerson);
        }
    }
}
