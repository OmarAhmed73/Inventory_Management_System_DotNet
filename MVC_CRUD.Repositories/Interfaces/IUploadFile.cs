using Microsoft.AspNetCore.Http;

namespace MVC_CRUD.Repositories.Interfaces
{
    public interface IUploadFile
    {
         Task<string> UploadFileAsync(string filePath, IFormFile file);
    }
}
