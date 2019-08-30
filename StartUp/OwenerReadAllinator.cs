using PetShopApp.Core.ApplicationService;
using PetShopApp.UI.ConsoleView.Actionator;

namespace StartUp
{
    internal class OwenerReadAllinator : IActionator
    {
        private IOwnerService ownerService;

        public OwenerReadAllinator(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

        public void go()
        {
            throw new System.NotImplementedException();
        }
    }
}