﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataAccess.Models.Database;

public class User
{
    public int Id { get; set; } = 0;

    [Required, EmailAddress]
    public string Email { get; set; }

    public int CustomerId { get; set; }
    [JsonIgnore]
    public virtual Customer Customer { get; set; }

    [JsonIgnore]
    public DateTime RefreshTokenExpirationTime { get; set; }
    [JsonIgnore]
    public string RefreshToken { get; set; }

    [Required]
    public byte[] PasswordHash { get; set; }

    [Required]
    public byte[] PasswordSalt { get; set; }

}
