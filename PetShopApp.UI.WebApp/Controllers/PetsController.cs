using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entity;
using PetShopApp.UI.WebApp.DTO;

namespace PetShopApp.UI.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly IOwnerService _ownerService;

        public PetsController(IPetService petService, IOwnerService ownerService)
        {
            this._ownerService = ownerService;
            this._petService = petService;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            try
            {
                return _petService.ReadAllPet();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            try
            {
                return _petService.ReadPetByID(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // POST api/values
        //[HttpPost]
        //public ActionResult<Pet> Post([FromBody] Pet pet)
        //{
        //    try
        //    {
        //        return _petService.CreatePet(pet);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
            
        //}

        [HttpPost]
        public ActionResult<Pet> Post([FromBody] DTOCreatePetWithOwner pet)
        {
            try
            {
                return _petService.CreatePet(
                    new Pet()
                    {
                        Name = pet.Name,
                        PriviousOwner = _ownerService.ReadOwner(pet.PriviousOwnerID),
                        BirthDate = pet.BirthDate,
                        Color = pet.Color,
                        Price = pet.Price,
                        Type = pet.PType
                        
                    });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            try
            {
                return _petService.UpdatePet(pet);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            pet.Id = id;
            
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            try
            {
                return _petService.DeletePet(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
