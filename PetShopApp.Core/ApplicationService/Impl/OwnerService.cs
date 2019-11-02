using PetShopApp.Core.DomainService;
using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PetShopApp.Core.ApplicationService.Impl
{
    public class OwnerService : IOwnerService
    {
        private IRepository<Owner> _repo;

        public OwnerService(IRepository<Owner> ownerRepo)
        {
            this._repo = ownerRepo;
        }

        #region C.R.U.D
        public Owner CreateOwner(Owner owner)
        {
            Owner tempOwner = owner;

            if (CheckNameContainsNumbers(owner))
            {
                throw new InvalidDataException("Name can not contain a Numeric value.");
            }
            if (CheckNameTooShort(owner))
            {
                throw new InvalidDataException("Name is too short, it must be 3 or more character.");
            }
            if (!CheckPhoneNumberIsNumeric(owner))
            {
                throw new InvalidDataException("Phone Number Contain 1 or more letters and spaces.");
            }
            if (checkPhoneNUmmberTooShort(owner))
            {
                throw new InvalidDataException("Phone number must be 8 Numeric Characters long.");
            }
            if (CheckEmail(owner))
            {
                throw new InvalidDataException("Email not valid");
            }

            owner = _repo.Create(owner);

            if (!CheckIfIDWasAssiged(owner))
            {
                _repo.Delete(tempOwner);
                throw new InvalidOperationException("ID was Assigned properly. \nThe Funktion \"Creat New Owner\" does not work at the moment.");
            }


            return owner;
        }

        public List<Owner> ReadAllOwner()
        {
            return _repo.ReadAll().ToList();
        }

        public Owner ReadOwner(int id)
        {
            if (!CheckIfExist(id))
            {
                throw new InvalidDataException("ID does not exsist.");
            }

            return _repo.Read(id);
        }

        public Owner UpdateOwner(Owner owner)
        {
            if (CheckNameContainsNumbers(owner))
            {
                throw new InvalidDataException("Name can not contain a Numeric value.");
            }
            if (CheckNameTooShort(owner))
            {
                throw new InvalidDataException("Name is too short, it must be 3 or more character.");
            }
            if (!CheckPhoneNumberIsNumeric(owner))
            {
                throw new InvalidDataException("Phone Number Contain 1 or more letters and spaces.");
            }
            if (checkPhoneNUmmberTooShort(owner))
            {
                throw new InvalidDataException("Phone number must be 8 Numeric Characters long.");
            }
            if (CheckEmail(owner))
            {
                throw new InvalidDataException("Email not valid.");
            }

            return _repo.Update(owner);
        }

        public Owner DeleteOwner(int id)
        {
            Owner owner = ReadOwner(id);

            _repo.Delete(owner);

            if (CheckIfExist(id))
            {
                throw new InvalidOperationException("Owner was not Deleted properly. \nThe Funktion \"Delete Owner\" does not work at the moment.");
            }

            return owner;
        }
        #endregion

        #region Checks
        private bool CheckIfExist(int id)
        {
            return _repo.Read(id) != null;
        }

        private static bool CheckNameContainsNumbers(Owner owner)
        {
            for (int i = 0; i < 10; i++)
            {
                if (owner.FirstName.Contains(i + "") || owner.LastName.Contains(i + ""))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckNameTooShort(Owner owner)
        {
            if (owner.FirstName.Length < 3)
            {
                return true;
            }
            return false;
        }

        private static bool CheckEmail(Owner owner)
        {
            if (!owner.Email.Contains("@") || !owner.Email.ToLower().Contains(".com"))
            {
                return true;
            }
            return false;
        }

        private static bool CheckPhoneNumberIsNumeric(Owner owner)
        {
            try
            {
                int convertTest = Convert.ToInt32(owner.PhoneNumber);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private static bool checkPhoneNUmmberTooShort(Owner owner)
        {
            if (owner.PhoneNumber.Length != 8)
            {
                return true;
            }
            return false;
        }
        private static bool CheckIfIDWasAssiged(Owner owner)
        {
            if (owner.HasId)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
