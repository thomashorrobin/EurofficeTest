using System.Collections.Generic;

namespace Euroffice.Services
{
    public interface ICatApiService
    {
        List<Image> GetImages(string categoryName);
		List<Category> GetCategories();
    }
}