using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShopApp.UI.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class OwnersController : Controller
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            this._ownerService = ownerService;
        }


        // GET: api/<controller>
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

        // GET api/<controller>/5
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

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Owner> Post([FromBody]Owner owner)
        {
            try
            {
                return _ownerService.CreateOwner(owner);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody]Owner owner)
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
                return _ownerService.UpdateOwner(oldOwner);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<controller>/5
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
