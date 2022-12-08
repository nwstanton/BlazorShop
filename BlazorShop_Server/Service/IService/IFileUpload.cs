using Microsoft.AspNetCore.Components.Forms;

namespace BlazorShop_Server.Service.IService
{
	public interface IFileUpload
	{
		Task<string> UploadFile(IBrowserFile file);

		bool DeleteFile(String filePath);
	}
}
