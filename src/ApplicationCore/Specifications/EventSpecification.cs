using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.Specification;
using Microsoft.eShopWeb.Infrastructure.Data.Queries;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications
{
    public class EventSpecification : Specification<Event>
    {
        public EventSpecification(List<int>? selectedEventTypesIds, List<int>? selectedEventLocationIds, bool? hasOnline)
        {
            Console.WriteLine("Here with specification: " + selectedEventLocationIds?.Count.ToString() + " " + selectedEventTypesIds?.Count.ToString());
            for (int i = 0; i < selectedEventLocationIds?.Count; i++)
            {
                Console.WriteLine(selectedEventLocationIds[i]);
            }

            for (int i = 0; i < selectedEventTypesIds?.Count(); i++)
            {
                Console.WriteLine(selectedEventTypesIds[i]);
            }
            if (selectedEventTypesIds != null && selectedEventTypesIds.Count > 0)
            {
               
                Query.Include(e => e.EventTypes).Where(e => e.EventTypes.Any(et => selectedEventTypesIds.Contains(et.Id)));
            }

            if (selectedEventLocationIds != null && selectedEventLocationIds.Count > 0)
            {
                Query.Include(e => e.EventLocations).Where(e => e.EventLocations.Any(el => selectedEventLocationIds.Contains(el.Id)));
            }
        }

        public EventSpecification(string userId)
        {
            Query.Include(e => e.Tickets).Where(e => e.Tickets.Any(t => t.UserId == userId));
        }
    }
}


