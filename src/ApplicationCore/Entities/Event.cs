using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Entities.TicketAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.Infrastructure.Data.Queries;

public class Event : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public string? PictureUri { get; private set; }
    
    public string? LinkToEvent { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public List<EventType> EventTypes { get; } = [];
    public List<EventLocation> EventLocations { get; } = [];    

    public List<TicketItem> Tickets { get; private set; }

    public Event()
    {
        
    }

    public Event(string name, decimal price, DateTime startDate)
    {
        Name = name;
        Price = price;
        StartDate = startDate;
    }

    public Event(string name, string description, decimal price, string pictureUri, DateTime startDate, DateTime endDate, List<EventType> eventTypes, List<EventLocation> eventLocations)
    {
        Name = name;
        Description = description;
        Price = price;
        PictureUri = pictureUri;
        StartDate = startDate;
        EndDate = endDate;
        EventTypes = eventTypes;
        EventLocations = eventLocations;
    }
    
    public void AddTicket(TicketItem ticket)
    {
        Guard.Against.Null(ticket, nameof(ticket));
        Tickets ??= new List<TicketItem>();
        Tickets.Add(ticket);
    }
    
    public void UpdateLinkToEvent(string linkToEvent)
    {
        Guard.Against.NullOrEmpty(linkToEvent, nameof(linkToEvent));
        LinkToEvent = linkToEvent;
    }
    
    public void UpdateDescription(string description)
    {
        Guard.Against.NullOrEmpty(description, nameof(description));
        Description = description;
    }
    
    public void UpdateEndDate(DateTime endDate)
    {
        Guard.Against.Default(endDate, nameof(endDate));
        EndDate = endDate;
    }
    
    public void UpdatePictureUri(string pictureName)
    {
        if (string.IsNullOrEmpty(pictureName))
        {
            PictureUri = string.Empty;
            return;
        }
        PictureUri = $"images\\events\\{pictureName}?{new DateTime().Ticks}";
    }
    
    
    public void UpdatePrice(decimal price)
    {
        Guard.Against.NegativeOrZero(price, nameof(price));
        Price = price;
    }
    
    public void UpdateStartDate(DateTime startDate)
    {
        Guard.Against.Default(startDate, nameof(startDate));
        StartDate = startDate;
    }
    
    public void UpdateName(string name)
    {
        Guard.Against.NullOrEmpty(name, nameof(name));
        Name = name;
    }
    


    public void RemoveEventLocation(EventLocation eventLocation)
    {
        Guard.Against.Null(eventLocation, nameof(eventLocation));
        EventLocations?.Remove(eventLocation);
    }
    
    public void RemoveEventType(EventType eventType)
    {
        Guard.Against.Null(eventType, nameof(eventType));
        EventTypes?.Remove(eventType);
    }
    
    
}
