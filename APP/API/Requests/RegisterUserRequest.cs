using System.ComponentModel.DataAnnotations;

namespace API.Requests;

public record RegisterUserRequest(
    [Required] string Email,
    [Required] string Name,
    [Required] string Password);