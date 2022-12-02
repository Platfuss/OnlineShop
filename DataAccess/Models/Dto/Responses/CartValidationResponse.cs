namespace DataAccess.Models.Dto.Responses;
public class CartValidationResponse
{
    public bool Success { get; set; }
    public List<Dictionary<string, uint>> Items { get; set; } = new List<Dictionary<string, uint>>();
}
