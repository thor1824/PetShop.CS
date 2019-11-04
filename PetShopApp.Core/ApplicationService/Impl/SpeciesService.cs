using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Core.ApplicationService.Impl
{
    public class SpeciesService : ISpeciesService
    {
        private readonly IRepository<Species> _repo;

        public SpeciesService(IRepository<Species> repo)
        {
            _repo = repo;
        }

        #region C.R.U.D
        public Species Create(Species species)
        {
            return _repo.Create(species);
        }

        public Species Delete(int id)
        {
            Species species = Read(id);
            return _repo.Delete(species);
        }

        public Species Read(long id)
        {
            return _repo.Read(id);
        }

        public List<Species> ReadAll()
        {
            return _repo.ReadAll().ToList();
        }

        public Species Update(Species species)
        {
            return _repo.Update(species);
        }
        #endregion
    }
}
