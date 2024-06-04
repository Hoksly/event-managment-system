using System.Collections.Generic;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.Infrastructure.Data.Queries;

namespace Microsoft.eShopWeb.ApplicationCore.Entities;

public class EventLocation : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public string? Address { get; private set; }
    public string? City { get; private set; }
    public string? State { get; private set; }
    public string? ZipCode { get; private set; }
    public string? PictureUri { get; private set; }
    public bool HasOnline { get; private set; }
    public string? Link { get; private set; }
    public int? Capacity { get; private set; }

    public IEnumerable<Event> Events { get; private set; } = new List<Event>();

    public EventLocation()
    {
        
    }
    public EventLocation(string name, bool hasOnline)
    {
        Name = name;
        HasOnline = hasOnline;
    }
    
    public void UpdateAddress(string address)
    {
        Address = address;
    }
    
    public void UpdateCity(string city)
    {
        City = city;
    }
    
    public void UpdateState(string state)
    {
        State = state;
    }
    
    public void UpdateZipCode(string zipCode)
    {
        ZipCode = zipCode;
    }
    
    public void UpdatePictureUri(string pictureUri)
    {
        PictureUri = pictureUri;
    }
    
    public void UpdateLink(string link)
    {
        Link = link;
    }
    
    public void UpdateCapacity(int capacity)
    {
        Capacity = capacity;
    }
    
    public void UpdateHasOnline(bool isOnline)
    {
        HasOnline = isOnline;
    }
    
    public void UpdateName(string name)
    {
        Name = name;
    }
    
    
    
}
