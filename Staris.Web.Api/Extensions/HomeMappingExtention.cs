using Microsoft.AspNetCore.Mvc;

namespace Staris.Web.Api.Extensions
{
	public static class HomeMappingExtention
	{
		public static void AddHomeMapping(this WebApplication app)
		{
			app.MapGet("/", [ApiExplorerSettings(IgnoreApi = true)] () =>
			{
				return Results.Redirect("/swagger");
			})
			.ExcludeFromDescription();

		}
	}
}
