using AutoMapper;
using Core.Interfaces;
using Infrastructure.Data.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController, Route("api/persons")]
    public class SidController
    {
        private readonly ApplicationDbContext _dbContext;

        public SidController(ApplicationDbContext dbContext)
        {            
            _dbContext = dbContext;
        }

        [HttpGet("areas")]
        public async Task<ActionResult<object>> GetPersonPerAreas()
        {
            var persons = await _dbContext.Personas.Where(x => x.AreaId != null)
               .Select(x => new
               {
                   AreaId = x.AreaId ?? null,
                   PersonaId = x.Id
               })
            .ToListAsync();

            var areaPerson = await _dbContext.AreaPersonas
                .Join(_dbContext.Personas, ap => ap.PersonaId, p => p.Id, (areaPerson, persona) => new
                {
                    areaPerson.AreaId,
                    areaPerson.PersonaId
                }).ToListAsync();

            return areaPerson;//persons.Union(areaPerson);
        }
            
            
            
            //=> Ok(await repository.Persons.GetAreaPersons());

        [HttpGet("area")]
        public async Task<ActionResult<object>> GetPersonArea()
        {
            return await _dbContext.Personas.Where(x => x.AreaId != null)
               .Select(x => new
               {
                   AreaId = x.AreaId ?? null,
                   PersonaId = x.Id
               })
            .ToListAsync();
        } 
        //=> Ok(await repository.Persons.GetAreaPerson());

    }
}
