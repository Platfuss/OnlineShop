using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models.Dto.Requests;

public class UserRequest
{
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
}
