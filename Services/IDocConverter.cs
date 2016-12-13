using Microsoft.AspNet.Http;
using System.Threading.Tasks;
using WebApplication_Webease_.Models;

namespace WebApplication_Webease_.Services
{
    public interface IDocConverter
    {
        Task ConvertWordToRazorViewAsync(IFormFile uploadedFile, Blog applicableModelObject);
    }
}
