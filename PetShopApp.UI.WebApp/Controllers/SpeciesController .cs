using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entity;
using PetShopApp.UI.WebApp.DTO;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShopApp.UI.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class SpeciesController : Controller
    {
        private readonly ISpeciesService _sp;

        public SpeciesController(ISpeciesService sp)
        {
            _sp = sp;
        }


        //[Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Species>> Get()
        {
            try
            {
                return _sp.ReadAll();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        //[Authorize]
        [HttpGet("{id}")]
        public ActionResult<Species> Get(int id)
        {
            try
            {
                return _sp.Read(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Species> Post([FromBody]Species species)
        {
            try
            {
                Species newSpecies = new Species
                {
                    Name = species.Name
                };
                return _sp.Create(newSpecies);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        //[Authorize(Roles = "Administrator")]
        [HttpPut]
        public ActionResult<Species> Put([FromBody]Species species)
        {
            try
            {
                return _sp.Update(species);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Species> Delete(int id)
        {
            try
            {
                return _sp.Delete(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
