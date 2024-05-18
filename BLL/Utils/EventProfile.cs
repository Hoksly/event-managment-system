using AutoMapper;
using BLL.Models;
using crm_minimal.Models;


namespace BLL.Utils
{

    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventBusinessModel>();
            CreateMap<EventBusinessModel, Event>();
        }
    }
}
