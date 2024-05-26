namespace Authentication.Domain.Entities
{
    public class JwtConfig
    {
        public required string PrivateKey { get; set; }
        public required string PublicKey { get; set; }
    }
}