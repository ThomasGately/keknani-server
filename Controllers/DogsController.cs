using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using keknani_server.Entities;
using keknani_server.Models.Dogs;
using keknani_server.Services;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;


namespace keknani_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogsController : BaseController
    {
        private readonly IDogService _dogService;
        private readonly IMapper _mapper;

        public DogsController(
            IDogService dogService,
            IMapper mapper)
        {
            _dogService = dogService;
            _mapper = mapper;
        }

        //[Authorize(Role.Admin)]
        [HttpGet]
        public ActionResult<IEnumerable<DogResponse>> GetAll()
        {
            var dogs = _dogService.GetAll();
            return Ok(dogs);
        }

        //[Authorize(Role.Admin)]
        [HttpGet("{id:int}")]
        public ActionResult<DogResponse> GetById(int id)
        {
            //admins can get any dog
            if (id != Account.Id && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var dog = _dogService.GetById(id);
            return Ok(dog);
        }

        //[Authorize(Role.Admin)]
        [HttpPost]
        public ActionResult<DogResponse> Create(DogCreateRequest model)
        {
            var dog = _dogService.Create(model);
            return Ok(dog);
        }

        //[Authorize(Role.Admin)]
        [HttpPut("{id:int}")]
        public ActionResult<DogResponse> Update(int id, [FromForm] DogUpdateRequest model)
        {
            var dog = _dogService.Update(id, model);
            return Ok(dog);
        }

        //[Authorize(Role.Admin)]
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _dogService.Delete(id);
            return Ok(new { message = "Account deleted successfully" });
        }

        // helper methods

    }
}