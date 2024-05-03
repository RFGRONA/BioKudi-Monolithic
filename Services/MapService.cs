using BioKudi.dto;
using BioKudi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BioKudi.Services
{
    public class MapService
    {
        private readonly PlaceRepository placesRepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public MapService(PlaceRepository placesRepo, IHttpContextAccessor httpContextAccessor)
        {
            this.placesRepo = placesRepo;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<PlaceDto> GetMarkers()
        {
            return placesRepo.GetMarkers();
        }

        public ContentResult GetInfoPlace(int placeId)
        {
            var place = placesRepo.GetPlace(placeId);
            var html = "<table>" +
                "<tr><th><span><h1>" + place.NamePlace + "</h1></span></th></tr>" +
                "<tr><td><span class='title'>Actividad</span><br><p>" + place.ActivityId + "</p></td></tr>" +
                "<tr><td><span class='title'>Dirección</span><br><p>" + place.Address + "</p></td></tr>" +
                "<tr><td><span class='title'>Descripción</span><br><p>" + place.Description + "</p></td></tr>" +
                "<tr><td><span class='title'>Enlace</span><br><p>" + place.Link + "}</p></td></tr>" +
                "<tr><td> <a asp-controller=\"Home\" asp-action=\"Index\">Volver al inicio</a></td></tr>" +
                "</table>";
            return new ContentResult
            {
                Content = html,
                ContentType = "text/html"
            };
        }
    }
}
