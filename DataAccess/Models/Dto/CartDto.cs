using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models.Dto;

public class CartDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ItemId { get; set; }
    [Range(0, int.MaxValue)]
    public int Amount { get; set; }
    public byte[] Image { get; set; }
}
