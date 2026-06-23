using System.ComponentModel.DataAnnotations;

namespace API.Requests;

public record LoginUserRequest(
    [Required] string Email,
    [Required] string Password);