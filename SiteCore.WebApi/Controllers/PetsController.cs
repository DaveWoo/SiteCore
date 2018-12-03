﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SiteCore.WebApi.Utils;
using WebApiSample.DataAccess.Models;
using WebApiSample.DataAccess.Repositories;

namespace WebApiSample.Api._21.Controllers
{
    #region snippet_PetsController
    //[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : Controller
    {
        private readonly PetsRepository _repository;

        private readonly AppSettings _appSettings;

        private readonly ILogger<PetsController> _logger;

        public PetsController(PetsRepository repository, IOptions<AppSettings> settings, ILogger<PetsController> logger)
        {
            _appSettings = settings.Value;
            _repository = repository;
            _logger = logger;
            _logger.LogInformation("PetsController");
        }

        [HttpGet, ActionName("g")]
        public async Task<ActionResult<List<Pet>>> GetAllAsync()
        {
            var Message = $"About page visited at";
            return await _repository.GetPetsAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Pet>> GetByIdAsync(int id)
        {
            var pet = await _repository.GetPetAsync(id);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        ///Prevent xsrf atteck with property ValidateAntiForgeryToken
        public async Task<ActionResult<Pet>> CreateAsync([FromBody]Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.AddPetAsync(pet);

            return CreatedAtAction(nameof(GetByIdAsync),
                new { id = pet.Id }, pet);
        }
    }
    #endregion
}
