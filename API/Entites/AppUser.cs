

using System.ComponentModel.DataAnnotations;

namespace API.Entites;

public class AppUser
{
    [Key]
    public int Id { get; set; }

    public required string Name { get; set; }

    public required byte[] PasswordHash { get; set; }

    public required byte[]? PasswordSalt { get; set; }
}
