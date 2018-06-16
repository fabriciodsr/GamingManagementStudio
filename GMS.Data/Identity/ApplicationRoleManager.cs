using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using GMS.Data.Context;
using Microsoft.AspNet.Identity.Owin;

namespace GMS.Data.Identity
{
    public class ApplicationRoleManager : RoleManager<CustomRole, int>
    {
        public ApplicationRoleManager(CustomRoleStore store)
            : base(store)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new CustomRoleStore(context.Get<GMSContext>()));
        }
    }
}
