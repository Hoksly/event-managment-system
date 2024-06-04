using Microsoft.AspNetCore.Mvc.Rendering;
using Mono.TextTemplating;

namespace Microsoft.eShopWeb.Web.ViewModels;

public class CatalogIndexViewModel
{
    public List<CatalogItemViewModel> CatalogItems { get; set; } = new List<CatalogItemViewModel>();
    public List<SelectListItem>? Brands { get; set; } = new List<SelectListItem>();
    public List<TypeViewModel>? Types { get; set; } = new List<TypeViewModel>();
    
    public List<LocationViewModel>? Locations { get; set; } = new List<LocationViewModel>();

    public PaginationInfoViewModel? PaginationInfo { get; set; }
    
    public List<EventViewModel> Events { get; set; } = new List<EventViewModel>();
    
    
}
