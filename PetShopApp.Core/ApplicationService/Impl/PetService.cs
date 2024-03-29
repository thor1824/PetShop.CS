﻿using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using PetShopApp.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PetShopApp.Core.ApplicationService.Impl
{
    public class PetService : IPetService
    {
        private readonly IRepository<Pet> _repo;

        public PetService(IRepository<Pet> repo)
        {
            _repo = repo;
        }

        #region C.R.U.D
        public Pet CreatePet(Pet pet)
        {
            Pet tempPet = pet;
            if (CheckNameContainsNumbers(pet))
            {
                throw new InvalidDataException("Name can not contain a Numeric value.");
            }
            if (CheckNameTooShort(pet))
            {
                throw new InvalidDataException("Name is too short, it must be 3 or more character.");
            }

            pet = _repo.Create(pet);

            if (!pet.HasId)
            {
                _repo.Delete(tempPet);
                throw new InvalidOperationException("ID was Assigned properly. \nThe Funktion \"Creat New Owner\" does not work at the moment.");
            }

            return pet;
        }
        public Pet ReadPetByID(int id)
        {
            if (!CheckIfExist(id))
            {
                throw new InvalidDataException("ID does not exsist.");
            }

            return _repo.Read(id);
        }
        public PagedList<Pet> ReadAllPet(PageFilter pf)
        {
            IEnumerable<Pet> list = _repo.ReadAll();
            int total = list.Count();
            int pageTotal = total / pf.PageSize;
            return new PagedList<Pet>()
            {
                Data = list.Skip((pf.PageIndex) * pf.PageSize).Take(pf.PageSize).ToList(),
                ItemsPrPage = pf.PageSize,
                ItemsTotal = total,
                PageIndex = pf.PageIndex,
                PageTotal = pageTotal
            };

        }


        public Pet UpdatePet(Pet pet)
        {
            if (CheckNameContainsNumbers(pet))
            {
                throw new InvalidDataException("Name can not contain a Numeric value.");
            }
            if (CheckNameTooShort(pet))
            {
                throw new InvalidDataException("Name is too short, it must be 3 or more character.");
            }

            return _repo.Update(pet);
        }

        public Pet DeletePet(int id)
        {
            Pet pet = ReadPetByID(id);
            _repo.Delete(pet);

            if (CheckIfExist(id))
            {
                throw new InvalidOperationException("Owner was not Deleted properly. \nThe Funktion \"Delete Owner\" does not work at the moment.");
            }

            return pet;
        }

        public List<Pet> SeachByType(Species species)
        {
            return _repo.ReadAll().Where((pet) => pet.Species.Id.Equals(species)).ToList();
        }


        public List<Pet> ReadAllByCheapest()
        {
            return _repo.ReadAll().OrderBy(p1 => p1.Price).ToList();
        }
        #endregion

        #region Checks
        private static bool CheckNameContainsNumbers(Pet pet)
        {
            for (int i = 0; i < 10; i++)
            {
                if (pet.Name.Contains(i + ""))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckNameTooShort(Pet pet)
        {
            if (pet.Name.Length < 3)
            {
                return true;
            }
            return false;
        }

        private bool CheckIfExist(int id)
        {
            return _repo.Read(id) != null;
        }

        #endregion
    }
}
