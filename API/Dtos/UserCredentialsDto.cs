using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class UserCredentialsDto
{
    [Required]
    public int CompanyId { get; set; }
    [EmailAddress, Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}
