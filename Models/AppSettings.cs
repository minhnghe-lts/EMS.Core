namespace EMS.Core.Models
{
    public class AppSettings
    {
        public Jwt Jwt { get; set; }
    }

    public class Jwt
    {
        public string SecretKey { get; set; }
    }
}
