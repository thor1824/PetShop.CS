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

        [HttpPost]
        public ActionResult<Pet> Post([FromBody] DTOCreatePet dto)
        {
            try
            {
                Pet newPet = new Pet()
                {
                    Name = dto.Name,
                    BirthDate = dto.BirthDate,
                    Color = dto.Color,
                    Price = dto.Price,
                    PType = dto.PType

                };
                if (dto.PriviousOwnerID != null)
                {
                    newPet.PriviousOwner = _ownerService.ReadOwner(dto.PriviousOwnerID.Value);
                }
                return _petService.CreatePet(newPet);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] DTOUpdatePet dto)
        {
            try
            {
                Pet pet = _petService.ReadPetByID(id);
                if (dto.Name != null)
                {
                    pet.Name = dto.Name; 
                }
                if (dto.PType != null)
                {
                    pet.PType = dto.PType;
                }
                if (dto.BirthDate != null)
                {
                    pet.BirthDate = dto.BirthDate;
                }
                if (dto.SoldDate != null)
                {
                    pet.SoldDate = dto.SoldDate; 
                }
                if (dto.Price != null)
                {
                    pet.Price = dto.Price;
                }
                if (dto.Color != null)
                {
                    pet.Color = dto.Color;
                }
                if (dto.PriviousOwnerID != null)
                {
                    pet.PriviousOwner = _ownerService.ReadOwner(dto.PriviousOwnerID.Value);// new Owner() { Id = pet.PriviousOwnerID };
                }

                return _petService.UpdatePet(pet);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
