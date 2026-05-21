using System.Security.Principal;

namespace ERP.Entities
{


    public class User
    {

        public string? Username { get; set; }
        public string? Password { get; set; }



        public string? Name => Username;

        public IPrincipal? CurrentPrincipal { get; set; }

        public bool IsAuthenticated => CurrentPrincipal?.Identity?.IsAuthenticated ?? !string.IsNullOrEmpty(Username);

        protected virtual IPrincipal? InternalPrincipal { get; set; }

        public bool IsInRole(string role) => CurrentPrincipal?.IsInRole(role) ?? false;
    }
}