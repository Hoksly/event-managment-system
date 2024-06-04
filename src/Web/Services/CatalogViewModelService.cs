using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using Microsoft.eShopWeb.Infrastructure.Data.Queries;
using Microsoft.eShopWeb.Web.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.eShopWeb.Web.Services;

/// <summary>
/// This is a UI-specific service so belongs in UI project. It does not contain any business logic and works
/// with UI-specific types (view models and SelectListItem types).
/// </summary>
public class CatalogViewModelService : ICatalogViewModelService
{
    private readonly ILogger<CatalogViewModelService> _logger;
    private readonly IRepository<CatalogItem> _itemRepository;
    private readonly IRepository<CatalogBrand> _brandRepository;
    private readonly IRepository<CatalogType> _typeRepository;

    private readonly IRepository<EventType> _eventTypeRepository;
    private readonly IRepository<Event> _eventRepository;
    private readonly IRepository<EventLocation> _locationRepository;

    private readonly IUriComposer _uriComposer;

    public CatalogViewModelService(
        ILoggerFactory loggerFactory,
        IRepository<CatalogItem> itemRepository,
        IRepository<CatalogBrand> brandRepository,
        IRepository<CatalogType> typeRepository,
        IUriComposer uriComposer,
        IRepository<EventType> eventTypeRepository,
        IRepository<Event> eventRepository,
        IRepository<EventLocation> locationRepository)
    {
        _logger = loggerFactory.CreateLogger<CatalogViewModelService>();
        _itemRepository = itemRepository;
        _brandRepository = brandRepository;
        _typeRepository = typeRepository;
        _uriComposer = uriComposer;

        _eventRepository = eventRepository;
        _eventTypeRepository = eventTypeRepository;
        _locationRepository = locationRepository;
    }

    public async Task<CatalogIndexViewModel> GetCatalogItems(int pageIndex, int itemsPage, List<LocationViewModel>? locationSelected, List<TypeViewModel>? typesSelected)
    {
        Console.WriteLine("GetCatalogItems called." + locationSelected.Count() + " locations and " + typesSelected.Count() + " types.");


        var totalItems = await _eventRepository.CountAsync();
        

        var eventFilterSpecification = new EventSpecification((await GetSelectedIds(typesSelected)), await GetSelectedIds(locationSelected), null);
        if (locationSelected.IsNullOrEmpty())
            locationSelected = (await GetLocations()).ToList();
        if(typesSelected.IsNullOrEmpty())
            typesSelected = (await GetTypes()).ToList();
        
        var eventsOnPage = await _eventRepository.ListAsync(eventFilterSpecification);
        
        var vm = new CatalogIndexViewModel()
        {
            CatalogItems = null,
            Brands = (await GetBrands()).ToList(),
            Types = typesSelected,
            Locations = locationSelected,
            Events = eventsOnPage.Select(i => new EventViewModel()
            {
                Name = i.Name,
                Description = i.Description,    
                Price = i.Price,
                PictureUri = _uriComposer.ComposePicUri(i.PictureUri),
                StartDate = i.StartDate,
                Id = i.Id
            }).ToList(),
            PaginationInfo = new PaginationInfoViewModel() { ActualPage = pageIndex, ItemsPerPage = eventsOnPage.Count, TotalItems = totalItems, TotalPages = int.Parse(Math.Ceiling(((decimal)totalItems / itemsPage)).ToString()) }
        };


        vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
        vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";

        return vm;
    }

    private async Task<List<int>>? GetSelectedIds<T>(List<T>? items) where T : class
    {
        Console.WriteLine("GetSelectedIds called." + items?.Count() + " items.");
        List<int> selectedIds = new List<int>();
        if(items == null)
        {
            Console.WriteLine("Items is null.");
            return null;
        }
    
        foreach (var item in items)
        {
            var selectedItem = item as dynamic;
            Console.WriteLine(selectedItem.Selected + " " + selectedItem.Name + " " + selectedItem.Id);
            if (selectedItem.Selected)
            {
                Console.WriteLine(selectedItem.Selected + " " + selectedItem.Name + " " + selectedItem.Id);
                if (selectedItem.Name == "All")
                {
                    return null;
                }
                Console.WriteLine("Has value: " + selectedItem.Name);
                selectedIds.Add(selectedItem.Id);
            }
        }

        return selectedIds;
    }

    public async Task<IEnumerable<SelectListItem>> GetBrands()
    {
        _logger.LogInformation("GetBrands called.");
        var brands = await _brandRepository.ListAsync();

        var items = brands
            .Select(brand => new SelectListItem() { Value = brand.Id.ToString(), Text = brand.Brand })
            .OrderBy(b => b.Text)
            .ToList();

        var allItem = new SelectListItem() { Value = null, Text = "All", Selected = true };
        items.Insert(0, allItem);

        return items;
    }

    public async Task<IEnumerable<TypeViewModel>> GetTypes()
    {
        _logger.LogInformation("GetTypes called.");
        var types = await _eventTypeRepository.ListAsync();
        foreach (var type in types)
        {
            Console.WriteLine(type.Name + " " +type.Id);
        }
        var items = types
            .Select(type => new TypeViewModel() { Id = type.Id, Name = type.Name })
            .OrderBy(t => t.Name)
            .ToList();

        var allItem = new TypeViewModel() { Id = -1, Name = "All", Selected = true };
        items.Insert(0, allItem);

        return items;
    }


    public async Task<IEnumerable<LocationViewModel>> GetLocations()
    {
        _logger.LogInformation("GetLocations called.");

        var locations = await _locationRepository.ListAsync();

        var locationItems = locations
            .Select(l => new LocationViewModel() { Id = l.Id, Name = l.Name })
            .OrderBy(l => l.Name)
            .ToList();

        var allItem = new LocationViewModel() { Name = "All", Selected = true, Id = -1 };

        locationItems.Insert(0, allItem);

        return locationItems;
    }
}
