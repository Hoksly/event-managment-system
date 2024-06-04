namespace Microsoft.eShopWeb.Web.ViewModels;

public class EventViewModel
{

    public int Id { get;  set; }
     public string Name { get;  set; }
     public string? Description { get;  set; }
     public decimal Price { get;  set; }
     public string? PictureUri { get;  set; }
     public DateTime StartDate { get; set; }
     public DateTime EndDate { get; set; }
     
     public string? LinkToEvent { get; set; }
     public bool isOnline { get; set; }

}
