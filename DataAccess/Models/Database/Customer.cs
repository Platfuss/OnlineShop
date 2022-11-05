using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models.Database;

public class Customer
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Surname { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    public int DefaultInvoiceAddressId { get; set; }
    public virtual Address DefaultInvoiceAddress { get; set; }

    public int? DefaultShipingAddressId { get; set; }
    public virtual Address DefaultShipingAddress { get; set; }
}
