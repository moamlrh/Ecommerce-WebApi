namespace Ecommerce.Api.JwtConfig;

public class JWTOptions
{
    public JWTOptions() { }
    public string secretKey { get; set; } = string.Empty;
    public string validIssuer { get; set; } = string.Empty;
    public string validAudience { get; set; } = string.Empty;
    public string expires { get; set; } = string.Empty;
}
