using System.Security.Principal;

namespace ERP.Entities
{
    // Minimal User entity with Username and Password to satisfy usages in UI.
    // Adjust or merge into your existing User implementation if you already have one.
    public class User
    {
        // Properties used by Form1
        public string? Username { get; set; }
        public string? Password { get; set; }

        // Additional helpers that match signatures you showed in diagnostics context.
        // These are simple implementations; update them to fit your authentication model.
        public string? Name => Username;

        public IPrincipal? CurrentPrincipal { get; set; }

        public bool IsAuthenticated => CurrentPrincipal?.Identity?.IsAuthenticated ?? !string.IsNullOrEmpty(Username);

        protected virtual IPrincipal? InternalPrincipal { get; set; }

        public bool IsInRole(string role) => CurrentPrincipal?.IsInRole(role) ?? false;
    }
}