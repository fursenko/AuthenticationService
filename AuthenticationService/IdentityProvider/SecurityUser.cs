using System.Security.Principal;

namespace AuthenticationService.IdentityProvider
{
    public class SecurityUser : IIdentity
    {
        public int Id { get; set; }
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
