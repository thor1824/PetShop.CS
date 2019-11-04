using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entity;
using PetShopApp.UI.WebApp.DTO;
using System;
using System.Collections.Generic;

namespace PetShopApp.UI.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly IOwnerService _ownerService;
        private readonly ISpeciesService _speciesService;
        public PetsController(IPetService petService, IOwnerService ownerService, ISpeciesService speciesService)
        {
            this._ownerService = ownerService;
            this._petService = petService;
            this._speciesService = speciesService;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<PagedList<DTOGetPet>> Get([FromQuery]int pageIndex, [FromQuery]int pageSize)
        {

            try
            {
                PagedList<Pet> pets = _petService.ReadAllPet(new PageFilter() { PageSize = pageSize, PageIndex = pageIndex });
                List<DTOGetPet> temp = new List<DTOGetPet>();

                foreach (var pet in pets.Data)
                {
                    List<Owner> po = new List<Owner>();
                    foreach (var ownerPet in pet.PreviousOwners)
                    {
                        po.Add(ownerPet.Owner);
                    }
                    temp.Add(new DTOGetPet()
                    {
                        Id = pet.Id,
                        Name = pet.Name,
                        Species = pet.Species,
                        BirthDate = pet.BirthDate,
                        SoldDate = pet.SoldDate,
                        Price = pet.Price,
                        Color = pet.Color,
                        ImageUrl = pet.ImageUrl,
                        PreviousOwners = po

                    });
                }

                return new PagedList<DTOGetPet>()
                {
                    Data = temp,
                    ItemsPrPage = pets.ItemsPrPage,
                    ItemsTotal = pets.ItemsTotal,
                    PageIndex = pets.PageIndex,
                    PageTotal = pets.PageTotal
                };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<DTOGetPet> Get(int id)
        {
            try
            {
                Pet pet = _petService.ReadPetByID(id);
                List<Owner> po = new List<Owner>();
                foreach (var ownerPet in pet.PreviousOwners)
                {
                    po.Add(ownerPet.Owner);
                }
                return new DTOGetPet()
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    Species = pet.Species,
                    BirthDate = pet.BirthDate,
                    SoldDate = pet.SoldDate,
                    Price = pet.Price,
                    Color = pet.Color,
                    ImageUrl = pet.ImageUrl,
                    PreviousOwners = po

                };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] DTOCreatePet dto)
        {
            try
            {
                Pet newPet = new Pet()
                {
                    Name = dto.Name,
                    ImageUrl = dto.ImageUrl,
                    BirthDate = dto.BirthDate,
                    SoldDate = dto.SoldDate,
                    Color = dto.Color,
                    Price = dto.Price,
                    Species = _speciesService.Read(dto.Species)

                };
                if (dto.PriviousOwners != null)
                {
                    List<PetOwner> List = new List<PetOwner>();
                    for (int i = 0; i < dto.PriviousOwners.Length; i++)
                    {
                        PetOwner temp = new PetOwner()
                        {
                            Pet = newPet,
                            PetID = newPet.Id.Value,
                            Owner = _ownerService.ReadOwner(dto.PriviousOwners[i]),
                            OwnerID = dto.PriviousOwners[i]
                        };

                        List.Add(temp);
                    }
                    newPet.PreviousOwners = List;

                }
                return _petService.CreatePet(newPet);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        public ActionResult<Pet> Put([FromBody] DTOUpdatePet dto)
        {
            try
            {
                Pet pet = _petService.ReadPetByID(dto.Id);
                if (dto.Name != null)
                {
                    pet.Name = dto.Name;
                }
                if (dto.Species != null)
                {
                    pet.Species = _speciesService.Read(dto.Species);
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
                if (dto.PriviousOwners != null)
                {
                    List<PetOwner> updatedList = new List<PetOwner>();
                    for (int i = 0; i < dto.PriviousOwners.Length; i++)
                    {
                        PetOwner temp = new PetOwner()
                        {
                            Pet = pet,
                            PetID = pet.Id.Value,
                            Owner = _ownerService.ReadOwner(dto.PriviousOwners[i]),
                            OwnerID = dto.PriviousOwners[i]
                        };

                        updatedList.Add(temp);
                    }
                    pet.PreviousOwners = updatedList;
                }

                return _petService.UpdatePet(pet);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Administrator")]
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
