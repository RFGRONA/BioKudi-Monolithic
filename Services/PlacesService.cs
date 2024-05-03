using BioKudi.dto;
using BioKudi.Models;
using BioKudi.Repository;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System;

public class PlacesService
{
	private readonly PlaceRepository placesRepo;
	private readonly IHttpContextAccessor httpContextAccessor;

	public PlacesService(PlaceRepository placesRepo, IHttpContextAccessor httpContextAccessor)
	{
		this.placesRepo = placesRepo;
		this.httpContextAccessor = httpContextAccessor;
	}

	//public PlacesDto CreatePlaces(PlacesDto places)
	//{
	//	var result = placesRepo.Create(places);
	//	if (result == null)
	//	{
	//		return null;
	//	}
	//	return places;
	//}

	public IEnumerable<PlaceDto> GetAllPlaces()
	{
		return placesRepo.GetListPlace();
	}

	public PlaceDto GetPlace(int placeId)
	{
		return placesRepo.GetPlace(placeId);
	}

	public IEnumerable<PlaceDto> GetMarkers()
	{
        return placesRepo.GetMarkers();
    }
    public IEnumerable<PlaceDto> GetNameId()
    {
        return placesRepo.GetNameId();
    }

    public ContentResult GetInfoPlace(int placeId)
	{ 
        var place = placesRepo.GetPlace(placeId);
		var html = "<table>" +
			"<tr><th><span><h1>"+place.NamePlace+"</h1></span></th></tr>" +
			"<tr><td><span class='title'>Actividad</span><br><p>"+place.ActivityId+"</p></td></tr>" +
			"<tr><td><span class='title'>Dirección</span><br><p>"+place.Address+"</p></td></tr>" +
			"<tr><td><span class='title'>Descripción</span><br><p>"+place.Description+"</p></td></tr>" +
			"<tr><td><span class='title'>Enlace</span><br><p>"+place.Link+"}</p></td></tr>" +
            "<tr><td> <a asp-controller=\"Home\" asp-action=\"Index\">Volver al inicio</a></td></tr>" +
			"</table>";
		return new ContentResult
        {
            Content = html,
            ContentType = "text/html"
        };
    }
}
