namespace Staris.Application.Shared.Responses
{
	public record UserLoginResponse
	{
		public string UserName { get; set; }
		public string Token { get; set; }
	}
}
