using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShopApp.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShopApp.Core.ApplicationService.Impl
{
    public class PetService : IPetService
    {
        private readonly IRepository<Pet> _repo;

        public PetService(IRepository<Pet> repo)
        {
            _repo = repo;
        }



        public void CreatePet(Pet pet)
        {
            _repo.Create(pet);
        }
        public Pet ReadPetByID(int id)
        {
            return _repo.Read(id);
        }
        public List<Pet> ReadAllPet()
        {
            return _repo.ReadAll().ToList();
        }
        public Pet UpdatePet(Pet pet)
        {
            return null;
        }

        public Pet DeletePet(int id)
        {
            _repo.Delete(id);
            return null;
        }

        public List<Pet> SeachByType(PetType.PType type)
        {
            return _repo.ReadAll().Where((pet) => pet.Type.Equals(type)).ToList();
        }

        public SortedList<int, PetType.PType> getPetTypeInSortedList()
        {
            SortedList<int, PetType.PType> types = new SortedList<int, PetType.PType>();
            int i = 1;
            foreach (var item in PetType.GetTypes())
            {
                types.Add(i, item);
                i++;
            }
            return types;
        }

        public List<Pet> ReadAllByCheapest()
        {
            return _repo.ReadAll().OrderByDescending(p1 => p1.Price).ToList();
        }
    }
}
