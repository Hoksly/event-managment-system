using System.Collections.Generic;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.Infrastructure.Data.Queries;

namespace Microsoft.eShopWeb.ApplicationCore.Entities;

public class EventType : BaseEntity, IAggregateRoot
{
    public EventType()
    {
        
    }
    public string Name { get; private set; }
    public IEnumerable<Event> Events { get; private set; } = new List<Event>();
    
    public EventType(string name)
    {
        Name = name;
    }
    
    public void UpdateName(string name)
    {
        Name = name;
    }
}
