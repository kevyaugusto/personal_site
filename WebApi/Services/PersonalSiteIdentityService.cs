using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class PersonalSiteIdentityService : IPersonalSiteIdentityService
    {
        public string CurrentUser
        {
            get { return "test"; }
        }
    }
}
