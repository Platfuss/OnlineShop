using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataAccess.Models.Database;

public class User
{
    public int Id { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public byte[] PasswordHash { get; set; }

    [Required]
    public byte[] PasswordSalt { get; set; }

    public int CustomerId { get; set; }
    [JsonIgnore]
    public virtual Customer Customer { get; set; }
}
