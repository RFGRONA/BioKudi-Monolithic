using BioKudi.dto;
using BioKudi.Repository;

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
}
