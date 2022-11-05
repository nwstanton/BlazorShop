using Microsoft.JSInterop;

namespace BlazorShop_Server.Helpers
{
	public static class IJSRuntimeExtension
	{
		public static async ValueTask ToastrSuccess(this IJSRuntime jsRuntime, string message)
		{
            await jsRuntime.InvokeVoidAsync("ShowToastr", "success", message);

        }
        public static async ValueTask ToasterFailure(this IJSRuntime jsRuntime, string message)
		{
            await jsRuntime.InvokeVoidAsync("ShowToastr", "error", message);

        }
    }
}
