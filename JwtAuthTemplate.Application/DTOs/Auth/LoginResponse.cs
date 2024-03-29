namespace JwtAuthTemplate.Application.DTOs.Auth
{
	public record LoginResponse(bool Status, string Message = null!, string Token = null!);
}
