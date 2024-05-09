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

	public PlaceDto Create(PlaceDto places)
	{
		var result = placesRepo.Create(places);
		if (result == null)
		{
			return null;
		}
		return places;
	}

	public IEnumerable<PlaceDto> GetAllPlaces()
	{
		return placesRepo.GetListPlace();
	}

	public PlaceDto GetPlace(int placeId)
	{
		return placesRepo.GetPlace(placeId);
	}

    public IEnumerable<PlaceDto> GetNameId()
    {
        return placesRepo.GetNameId();
    }

}
