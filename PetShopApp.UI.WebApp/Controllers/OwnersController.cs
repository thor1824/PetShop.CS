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
    public class OwnersController : Controller
    {
        private readonly IOwnerService _ownerService;
        private readonly IPetService _petService;

        public OwnersController(IOwnerService ownerService, IPetService petService)
        {
            this._ownerService = ownerService;
            this._petService = petService;
        }


        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            try
            {
                return _ownerService.ReadAllOwner();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            try
            {
                return _ownerService.ReadOwner(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Owner> Post([FromBody]DTOOwner owner)
        {
            try
            {
                Owner newOwner = new Owner
                {
                    FirstName = owner.FirstName,
                    LastName = owner.LastName,
                    Address = owner.Address,
                    Email = owner.Email,
                    PhoneNumber = owner.PhoneNumber
                };
                if (owner.PreviousOwnedPets != null)
                {
                    List<PetOwner> petList = new List<PetOwner>();
                    for (int i = 0; i < owner.PreviousOwnedPets.Length; i++)
                    {
                        petList.Add(new PetOwner()
                        {
                            PetID = owner.PreviousOwnedPets[i],
                            Pet = _petService.ReadPetByID(owner.PreviousOwnedPets[i]),
                            Owner = newOwner
                        });

                    }
                    newOwner.PreviousOwnedPets = petList;
                }
                return _ownerService.CreateOwner(newOwner);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody]DTOOwner owner)
        {
            try
            {
                Owner oldOwner = _ownerService.ReadOwner(id);
                if (owner.FirstName != null)
                {
                    oldOwner.FirstName = owner.FirstName;
                }
                if (owner.LastName != null)
                {
                    oldOwner.LastName = owner.LastName;
                }
                if (owner.Address != null)
                {
                    oldOwner.Address = owner.Address;
                }
                if (owner.Email != null)
                {
                    oldOwner.Email = owner.Email;
                }
                if (owner.PhoneNumber != null)
                {
                    oldOwner.PhoneNumber = owner.PhoneNumber;
                }
                if (owner.PreviousOwnedPets != null)
                {
                    List<PetOwner> petList = new List<PetOwner>();
                    for (int i = 0; i < owner.PreviousOwnedPets.Length; i++)
                    {
                        petList.Add(new PetOwner()
                        {
                            PetID = owner.PreviousOwnedPets[i],
                            Pet = _petService.ReadPetByID(owner.PreviousOwnedPets[i]),
                            Owner = oldOwner,
                            OwnerID = oldOwner.Id.Value
                        });

                    }
                    oldOwner.PreviousOwnedPets = petList;
                }
                return _ownerService.UpdateOwner(oldOwner);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            try
            {
                return _ownerService.DeleteOwner(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
