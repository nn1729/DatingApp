using System.ComponentModel.DataAnnotations;

namespace API.Entites;

public class AppUser
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
}
