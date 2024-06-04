using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Interfaces;

public interface IEventViewModelService
{
    public Task<EventViewModel> GetEventByIdAsync(int id);
    public Task<List<EventViewModel>> GetUserEvents(string userId);
}
