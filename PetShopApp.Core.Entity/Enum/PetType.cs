using System.Collections.Generic;

namespace PetShopApp.Core.Entity.Enum
{
    public class PetType
    {
        public enum PType { Cat, Dog, Goat }

        public static List<PType> GetTypes()
        {
            List<PType> types = new List<PType>();
            types.Add(PType.Cat);
            types.Add(PType.Dog);
            types.Add(PType.Goat);
            return types;

        }
    }
}
