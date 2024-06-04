using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Services;

public interface ICatalogViewModelService
{
    Task<CatalogIndexViewModel> GetCatalogItems(int pageIndex, int itemsPage, List<LocationViewModel>? locationsSelected, List<TypeViewModel>? typesSelected);
    Task<IEnumerable<SelectListItem>> GetBrands();
    Task<IEnumerable<TypeViewModel>> GetTypes();
    Task<IEnumerable<LocationViewModel>> GetLocations();
}
