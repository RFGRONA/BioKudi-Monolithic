﻿using BioKudi.dto;
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

	public PlaceDto CreatePlace(PlaceDto places)
	{
		var result = placesRepo.Create(places);
		if (result == null)
			return null;
		return places;
	}

	public IEnumerable<PlaceDto> GetAllPlaces()
	{
		return placesRepo.GetListPlace() ?? new List<PlaceDto>();
	}

	public PlaceDto GetPlace(int placeId)
	{
		return placesRepo.GetPlace(placeId);
	}

    public IEnumerable<PlaceDto> GetNameId()
    {
        return placesRepo.GetNameId();
    }

	public PlaceDto UpdatePlace(PlaceDto place)
    {
        return placesRepo.Update(place);
    }

    public bool DeletePlace(int placeId)
    {
        return placesRepo.Delete(placeId);
    }
}
