namespace Biblio.UtilityServices.Models.Auth
{
    public class AuthModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public string? ClientURI { get; set; }
    }
}
