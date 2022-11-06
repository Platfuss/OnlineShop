using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models.Database;

public class Address
{
    public int Id { get; set; } = 0;

    [Required]
    public string City { get; set; }

    [Required]
    public string Street { get; set; }

    [Required]
    public string Number { get; set; }

    public string SubNumber { get; set; }

    [Required, RegularExpression("^\\d{2}-\\d{3}$", ErrorMessage = "Niepoprawny kod pocztowy. Wzorzec to: 00-000")]
    public string PostalCode { get; set; }
}
