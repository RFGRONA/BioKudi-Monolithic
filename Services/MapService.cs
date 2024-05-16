using BioKudi.dto;
using BioKudi.Models;
using BioKudi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using System.Security.Claims;

namespace BioKudi.Services
{
    public class MapService
    {
        private readonly PlaceRepository placesRepo;
        private readonly ReviewRepository reviewRepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public MapService(PlaceRepository placesRepo, IHttpContextAccessor httpContextAccessor, ReviewRepository reviewRepo)
        {
            this.placesRepo = placesRepo;
            this.httpContextAccessor = httpContextAccessor;
            this.reviewRepo = reviewRepo;
        }

        public IEnumerable<PlaceDto> GetMarkers()
        {
            return placesRepo.GetMarkers();
        }

        // Bring information about the place for non-logged users.
        public ContentResult GetInfoPlace(int placeId)
        {
            var place = placesRepo.GetPlace(placeId);
            var html = "<table>" +
                "<tr><th><span><h1>" + place.NamePlace + "</h1></span></th></tr>" +
                "<tr><td><br><p>" + place.Rating + "</p></td></tr>" +
                "<tr><td><span class='title'>Actividades</span><br><ul>";
            foreach (var activity in place.ActivityData)
            {
                html += "<li>" + activity.Type + "</li>";
            }
            html += "</ul></td></tr>" +
                "<tr><td><span class='title'>Dirección</span><br><p>" + place.Address + "</p></td></tr>" +
                "<tr><td><span class='title'>Descripción</span><br><p>" + place.Description + "</p></td></tr>" +
                "<tr><td><span class='title'>Enlace</span><br><p>" + place.Link + "</p></td></tr>" +
            "</table>" +
                "<a href='#' onclick='showReviews(" + place.IdPlace +")'>Ver reseñas</a>" +
                "<a href=\"/Home/Index\">Volver al inicio</a>";

            return new ContentResult
            {
                Content = html,
                ContentType = "text/html"
            };
        }

        // Bring information about the place for logged users.
        public ContentResult GetInfoPlace(int placeId, HttpContext httpContext)
        {
            var userIdClaim = httpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            int idUser = 0;
            if (userIdClaim != null)
                if (int.TryParse(userIdClaim.Value, out int userId))
                    idUser = userId;
            var place = placesRepo.GetPlace(placeId);
            var html = "<table>" +
                "<tr><th><span><h1>" + place.NamePlace + "</h1></span></th></tr>" +
                "<tr><td><br><p>" + place.Rating + "</p></td></tr>" +
                "<tr><td><span class='title'>Actividades</span><br><ul>";
            foreach (var activity in place.ActivityData)
            {
                html += "<li>" + activity.Type + "</li>";
            }
            html += "</ul></td></tr>" +
                "<tr><td><span class='title'>Dirección</span><br><p>" + place.Address + "</p></td></tr>" +
                "<tr><td><span class='title'>Descripción</span><br><p>" + place.Description + "</p></td></tr>" +
                "<tr><td><span class='title'>Enlace</span><br><p>" + place.Link + "</p></td></tr>" +
            "</table>" +
                "<a href='#' onclick='showReviews(" + place.IdPlace + "," + idUser + ")'>Ver reseñas</a>" +
                "<a href=\"/Home/Index\">Volver al inicio</a>";

            return new ContentResult
            {
                Content = html,
                ContentType = "text/html"
            };
        }

        // Bring all reviews for non-logged users. 
        public ContentResult GetReviews(int idPlace)
        {
            var reviews = reviewRepo.GetReviewPlace(idPlace);
            var html = "<h2>Reseñas</h2><ul>"+
                "<a href='#' onclick='showPlaceInfo(" + idPlace + ")'>Volver al lugar</a>";
            if (reviews.Any())
            {
                html += "<ul>";
                foreach (var review in reviews)
                {
                    html += "<strong>Calificación:</strong> " + review.Rate + "<br>";
                    html += "<strong>Usuario:</strong> " + review.UserName + "<br>";
                    if (!string.IsNullOrWhiteSpace(review.Comment))
                    {
                        html += review.Comment;
                    }
                    html += "</li>";
                }
                html += "</ul>";
            }
            else
            {
                html += "<p>No hay reseñas todavía. Si desea dejar una reseña, por favor inicie sesión.</p>";
            }
            html += "<a href=\"/Home/Index\">Volver al inicio</a>";
            return new ContentResult
            {
                Content = html,
                ContentType = "text/html"
            };
        }

        // Bring all the reviews, the first being those of the logged in user
        public ContentResult GetReviews(int idPlace, int idUser)
        {
            var reviews = reviewRepo.GetReviewUser(idPlace, idUser);
            var html = "<h2>Reseñas</h2><ul>" +
               "<a href='#' onclick='showPlaceInfo(" + idPlace +")'>Volver al lugar</a>" +
               "<a href='#' onclick='CreateReview(" + idPlace+")'>Crear reseña</a>"; 
            if (reviews.Any())
            {
                html += "<ul>";
                foreach (var review in reviews)
                {
                    html += "<li>";
                    html += "<strong>Calificación:</strong> " + review.Rate + "<br>";
                    html += "<strong>Usuario:</strong> " + review.UserName + "<br>";
                    if (!string.IsNullOrWhiteSpace(review.Comment))
                    {
                        html += review.Comment;
                    }
                    if (review.UserId == idUser)
                    {
                        html += "<br>";
                        html += "<button onclick='updateReview(" + review.IdReview + ")'>Actualizar</button>";
                        html += "<button onclick='deleteReview(" + review.IdReview + ")'>Eliminar</button>";
                    }
                    html += "</li>";
                }
                html += "</ul>";
            }
            else
            {
                html += "<p>No hay reseñas todavía. ¡Sé el primero en dejar una!</p>"; 
            }
            html += "<a href=\"/Home/Index\">Volver al inicio</a>";
            return new ContentResult
            {
                Content = html,
                ContentType = "text/html"
            };
        }

        public ContentResult CreateReviewForm(int idPlace)
        {
            var html = "<h2>Crear reseña</h2>" +
                       "<form id='createReviewForm'>" +
                       "<label for='Rate'>Calificación:</label>" +
                       "<input type='number' id='Rate' name='Rate' min='1' max='5' required>" +
                       "<label for='Comment'>Comentario:</label>" +
                       "<textarea id='Comment' name='Comment' rows='4' cols='50'></textarea>" +
                       "<input type='hidden' name='PlaceId' value='" + idPlace + "'>" +
                       "<input type='submit' value='Enviar'>" +
                       "</form>";
            return new ContentResult
            {
                Content = html,
                ContentType = "text/html"
            };
        }

        public void CreateReview(ReviewDto review, HttpContext httpContext)
        {
            var userIdClaim = httpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
                if (int.TryParse(userIdClaim.Value, out int userId))
                    review.UserId = userId;
            reviewRepo.Create(review);
        }

        public ContentResult UpdateReviewForm(int idReview)
        {
            var review = reviewRepo.GetReview(idReview);
            var html = "<h2>Actualizar reseña</h2>" +
                       "<form id='updateReviewForm'>" +
                       "<label for='Rate'>Calificación:</label>" +
                       "<input type='number' id='Rate' name='Rate' min='1' max='5' value='" + review.Rate + "' required>" +
                       "<label for='Comment'>Comentario:</label>" +
                       "<textarea id='Comment' name='Comment' rows='4' cols='50'>" + review.Comment + "</textarea>" +
                       "<input type='hidden' name='IdReview' value='" + review.IdReview + "'>" +
                       "<input type='hidden' name='PlaceId' value='" + review.PlaceId + "'>" +
                       "<input type='submit' value='Actualizar'>" +
                       "</form>";
            return new ContentResult
            {
                Content = html,
                ContentType = "text/html"
            };
        }

        public void UpdateReview(ReviewDto review)
        {
            reviewRepo.Update(review);
        }

        public void DeleteReview(int idReview)
        {
            reviewRepo.Delete(idReview);
        }
    }
}
