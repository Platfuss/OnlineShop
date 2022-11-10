namespace DataAccess.Models.Dto.Responses;
public class TokenResponse
{
    public DateTime JwtExpirationDate { get; set; }
    public DateTime RefreshTokenExpirationDate { get; set; }
}
