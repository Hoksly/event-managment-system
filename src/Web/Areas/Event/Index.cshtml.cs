using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.Web.Interfaces;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Pages.Event;

public class Index : PageModel
{
    private IEventViewModelService _eventService;

    public Index(IEventViewModelService eventService)
    {
        _eventService = eventService;
    }

    public EventViewModel Event { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Event = await _eventService.GetEventByIdAsync(id);

        if (Event == null || Event.Id != id)
        {
            return NotFound();
        }

        return Page();
    }
}
