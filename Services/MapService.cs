using BioKudi.dto;
using BioKudi.Models;
using BioKudi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Sockets;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var head = @"
                        <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css"">
                        <link rel=""stylesheet"" href=""~/lib/font-awesome/css/all.min.css"" />
                        <link rel=""preconnect"" href=""https://fonts.googleapis.com"">
                        <link rel=""preconnect"" href=""https://fonts.gstatic.com"" crossorigin>
                        <link href=""https://fonts.googleapis.com/css2?family=Bitter:ital,wght@0,100..900;1,100..900&display=swap"" rel=""stylesheet"">
                        <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js""></script>
                        <script src=""https://cdn.jsdelivr.net/npm/sweetalert2@10""></script>
                        <link rel=""preconnect"" href=""https://fonts.googleapis.com"">
                        <link rel=""preconnect"" href=""https://fonts.gstatic.com"" crossorigin>
                        <link href=""https://fonts.googleapis.com/css2?family=Asul:wght@400;700&family=Inter:wght@100..900&display=swap"" rel=""stylesheet"">
                        <link rel=""stylesheet"" href=""~/lib/font-awesome/css/all.min.css"" />";
            var css = @"
        body {
            background-color: #FEECD6;
        }
        img {
            min-width: 50%;
            max-width: 100%;
            height: auto;
        }
        table{
            margin-left: 1%;
        }
        td {
            padding: 5px;
        }
        .title {
            font-size: 36px;
            font-weight: bold;
            text-align: left;
            color: #476930;
            margin-bottom: 2%;
            font-family: 'Bitter', serif;
            font-optical-sizing: auto;
        }
        .titulo {
            margin-bottom: 1%;
        }
        .icon {
            min-width: 10px;
            vertical-align: middle;
            color: #476930;
            font-size: 30px;
            vertical-align: top;
        }
        .iconn {
            text-align: left;
            vertical-align: top;
            font-size: 24px;
            text-align: left;
            color: #476930;
            margin-bottom: 2%;
            font-family: 'Bitter', serif;
            font-optical-sizing: auto;
        }
        .activity {
            text-align: left;
            vertical-align: top;
            font-size: 24px;
            text-align: left;
            color: #476930;
            margin-bottom: 2%;
            font-family: 'Bitter', serif;
            font-optical-sizing: auto;
        }
        .description {
            text-align: left;
            vertical-align: top;
            font-size: 24px;
            text-align: left;
            color: #476930;
            margin-bottom: 2%;
            font-family: 'Bitter', serif;
            font-optical-sizing: auto;
        }
        .rating {
            display: flex;
            text-align: left;
            font-weight: bold;
            vertical-align: top;
            font-size: 28px;
            text-align: left;
            color: #476930;
            margin-bottom: 2%;
            font-family: 'Bitter', serif;
            font-optical-sizing: auto;
            justify-content: space-between;
        }
        .review {
            text-align: right;
        }
        .iconWeb {
            color: #F67924;
        }
        .end {
            display: flex;
            text-align: left;
            font-weight: bold;
            vertical-align: top;
            font-size: 28px;
            text-align: left;
            color: #476930;
            margin-bottom: 2%;
            font-family: 'Bitter', serif;
            font-optical-sizing: auto;
            justify-content: space-between;
        }
        .pagina {
            color: #F67924;
        }
        .volver {
            color: #F67924;
        }
        .linkre {
            color: #F67924;
        }
    ";

            var html = "<head>"+head+ "</head><style>" + css + "</style>" +
                       "<table>" +
                       "<tr>" +
                       "<td class=\"image\" colspan=\"2\">";

            if (place.PictureData.Any())
            {
                html += "<img src=\"" + place.PictureData.FirstOrDefault().Link + "\" " +
                        "alt=\"" + place.PictureData.FirstOrDefault().Name + "\" />";
            }
            else
            {
                html += "<img src=\"https://cloudfront-us-east-1.images.arcpublishing.com/semana/UNB4UJO4OZEQZGEYGL6YQE74NM.jpg\" alt=\"No image\" />";
            }

            html += "</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td class=\"title\" colspan=\"2\">" +
                    "<div class=\"titulo\">" + place.NamePlace + "</div>" +
                    "</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td class=\"icon\"><i class=\"fa-solid fa-location-dot\"></i></td>" +
                    "<td class=\"iconn\">" + place.Address + "</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td class=\"icon\"><i class=\"fa-solid fa-person-hiking\"></i></td>" +
                    "<td class=\"activity\">";

            foreach (var item in place.ActivityData)
            {
                html += "<p>" + item.Type + "</p>";
            }

            html += "</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td class=\"icon\"><i class=\"fa-solid fa-file-lines\"></i></td>" +
                    "<td class=\"description\">" + place.Description + "</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td class=\"icon\"><i class=\"fa-solid fa-star-half-stroke\"></i></td>" +
                    "<td class=\"rating\"><div class=\"ratingdiv\">" + place.Rating + " / 5.0</div></td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td class=\"iconWeb\"><i class=\"fa-solid fa-arrow-up-right-from-square\"></i></td>" +
                    "<td class=\"end\">" +
                    "<a href=\"" + place.Link + "\" class=\"pagina\">Pagina Web</a>" +
                    "<div class=\"review\"><a href='#' onclick='showReviews(" + place.IdPlace + ")' class=\"linkre\">Ver reseñas</a></div>" +
                    "<a href=\"/Home/Index\" class=\"volver\">Volver al inicio</a>" +
                    "</td>" +
                    "</tr>" +
                    "</table>";

                        html, body {
                            height: 100%;
                            width: 100%;
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
            var head = @"
                        <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css"">
                        <link rel=""stylesheet"" href=""~/lib/font-awesome/css/all.min.css"" />
                        <link rel=""preconnect"" href=""https://fonts.googleapis.com"">
                        <link rel=""preconnect"" href=""https://fonts.gstatic.com"" crossorigin>
                        <link href=""https://fonts.googleapis.com/css2?family=Bitter:ital,wght@0,100..900;1,100..900&display=swap"" rel=""stylesheet"">
                        <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js""></script>
                        <script src=""https://cdn.jsdelivr.net/npm/sweetalert2@10""></script>
                        <link rel=""preconnect"" href=""https://fonts.googleapis.com"">
                        <link rel=""preconnect"" href=""https://fonts.gstatic.com"" crossorigin>
                        <link href=""https://fonts.googleapis.com/css2?family=Asul:wght@400;700&family=Inter:wght@100..900&display=swap"" rel=""stylesheet"">
                        <link rel=""stylesheet"" href=""~/lib/font-awesome/css/all.min.css"" />";
            var css = @"
        body {
            background-color: #FEECD6;
        }
        img {
            min-width: 50%;
            max-width: 100%;
            height: auto;
        }
        table{
            margin-left: 1%;
        }
        td {
            padding: 5px;
        }
        .title {
            font-size: 36px;
            font-weight: bold;
            text-align: left;
            color: #476930;
            margin-bottom: 2%;
            font-family: 'Bitter', serif;
            font-optical-sizing: auto;
        }
        .titulo {
            margin-bottom: 1%;
        }
        .icon {
            min-width: 10px;
            vertical-align: middle;
            color: #476930;
            font-size: 30px;
            vertical-align: top;
        }
        .iconn {
            text-align: left;
            vertical-align: top;
            font-size: 24px;
            text-align: left;
            color: #476930;
            margin-bottom: 2%;
            font-family: 'Bitter', serif;
            font-optical-sizing: auto;
        }
        .activity {
            text-align: left;
            vertical-align: top;
            font-size: 24px;
            text-align: left;
            color: #476930;
            margin-bottom: 2%;
            font-family: 'Bitter', serif;
            font-optical-sizing: auto;
        }
        .description {
            text-align: left;
            vertical-align: top;
            font-size: 24px;
            text-align: left;
            color: #476930;
            margin-bottom: 2%;
            font-family: 'Bitter', serif;
            font-optical-sizing: auto;
        }
        .rating {
            display: flex;
            text-align: left;
            font-weight: bold;
            vertical-align: top;
            font-size: 28px;
            text-align: left;
            color: #476930;
            margin-bottom: 2%;
            font-family: 'Bitter', serif;
            font-optical-sizing: auto;
            justify-content: space-between;
        }
        .review {
            text-align: right;
        }
        .iconWeb {
            color: #F67924;
        }
        .end {
            display: flex;
            text-align: left;
            font-weight: bold;
            vertical-align: top;
            font-size: 28px;
            text-align: left;
            color: #476930;
            margin-bottom: 2%;
            font-family: 'Bitter', serif;
            font-optical-sizing: auto;
            justify-content: space-between;
        }
        .pagina {
            color: #F67924;
        }
        .volver {
            color: #F67924;
        }
        .linkre {
            color: #F67924;
        }
    ";

            var html = "<head>" + head + "</head><style>" + css + "</style>" +
                       "<table>" +
                       "<tr>" +
                       "<td class=\"image\" colspan=\"2\">";

            if (place.PictureData.Any())
            {
                html += "<img src=\"" + place.PictureData.FirstOrDefault().Link + "\" " +
                        "alt=\"" + place.PictureData.FirstOrDefault().Name + "\" />";
            }
            else
            {
                html += "<img src=\"https://cloudfront-us-east-1.images.arcpublishing.com/semana/UNB4UJO4OZEQZGEYGL6YQE74NM.jpg\" alt=\"No image\" />";
            }

            html += "</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td class=\"title\" colspan=\"2\">" +
                    "<div class=\"titulo\">" + place.NamePlace + "</div>" +
                    "</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td class=\"icon\"><i class=\"fa-solid fa-location-dot\"></i></td>" +
                    "<td class=\"iconn\">" + place.Address + "</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td class=\"icon\"><i class=\"fa-solid fa-person-hiking\"></i></td>" +
                    "<td class=\"activity\">";

            foreach (var item in place.ActivityData)
            {
                html += "<p>" + item.Type + "</p>";
            }

            html += "</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td class=\"icon\"><i class=\"fa-solid fa-file-lines\"></i></td>" +
                    "<td class=\"description\">" + place.Description + "</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td class=\"icon\"><i class=\"fa-solid fa-star-half-stroke\"></i></td>" +
                    "<td class=\"rating\"><div class=\"ratingdiv\">" + place.Rating + " / 5.0</div></td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td class=\"iconWeb\"><i class=\"fa-solid fa-arrow-up-right-from-square\"></i></td>" +
                    "<td class=\"end\">" +
                    "<a href=\"" + place.Link + "\" class=\"pagina\">Pagina Web</a>" +
                    "<div class=\"review\"><a href='#' onclick='showReviews(" + place.IdPlace +"," + idUser + ")' class=\"linkre\">Ver reseñas</a></div>" +
                    "<a href=\"/Home/Index\" class=\"volver\">Volver al inicio</a>" +
                    "</td>" +
                    "</tr>" +
                    "</table>";

                        html, body {
                            height: 100%;
                            width: 100%;
                        }

        // Bring all reviews for non-logged users. 
        public ContentResult GetReviews(int idPlace)
        {
            var reviews = reviewRepo.GetReviewPlace(idPlace);
            var css = @"table{
                            margin-left: 1%;
                            min-width: 80%;
                            max-width: 80%;
                            text-colapse: collapse;
                            word-wrap: break-word;
                            word-break: break-all;
                            margin-bottom: 2%;
                        }
                        h1{
                            margin-left: 1%;
                            color: #476930;
                            font-family: 'Bitter', serif;
                            font-optical-sizing: auto;
                            font-weight: bold;
                        }
                        body{
                            background-color: #FEECD6;
                        }
                        td{
                            padding: 10px;
                            text-align: center;
                            //border: 1px solid black;
                        }
                        .rate {
                            text-align: center;
                            font-weight: bold;
                            
                            font-size: 28px;
                            color: #F67924;
                            font-family: 'Bitter', serif;
                            font-optical-sizing: auto;
                        }
                        .rate{
                            min-width: 150px;
                        }
                        .end{
                            font-weight: bold;
                            font-size: 20px;
                            color: #F67924;
                            font-family: 'Bitter', serif;
                            font-optical-sizing: auto;
                            display: flex;
                            justify-content: space-between;
                        }
                        .backk{
                            text-align: left;
                            margin-left: 20%;
                            color: #476930;
                        }
                        .index{
                            text-align: right;
                            margin-right: 20%;
                            color: #476930;
                        }
                        .user{
                            text-align: left;
                            font-weight: bold;
                            font-size: 20px;
                        }";
            var html = "<style>" + css + "</style>";
            html += "<h1>Reseñas</h1>";
            if (reviews.Any())
            {
                html += "<table>";
                foreach (var review in reviews)
                {
                    html += "<tr><td rowspan='2'><div  class='rate'>  " + review.Rate + " / 5.0</div> </td>";
                    html += "<td class='user'>" + review.UserName + "</td></tr>";
                    if (!string.IsNullOrWhiteSpace(review.Comment))
                    {
                        html += "<tr><td>" + review.Comment + "</td></tr>";
                    }
                }
                html += "</table>";
            }
            else
            {
                html += "<tr><td>No hay reseñas todavía. Si desea dejar una reseña, por favor inicie sesión.</td></tr>";
            }

            html += "<div class='end'><a href='#' onclick='showPlaceInfo(" + idPlace + ")' class='backk'>Volver al lugar</a>";
            html += "<a href=\\\"/Home/Index\\\" class=\"index\">Volver al inicio</a></div>";
            
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
               "<a href='#' onclick='showPlaceInfo(" + idPlace + ")'>Volver al lugar</a>" +
               "<a href='#' onclick='CreateReview(" + idPlace + ")'>Crear reseña</a>";
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
                       "<textarea id='Comment' maxlength='250' name='Comment' rows='4' cols='50'></textarea>" +
                       "<input type='hidden' name='PlaceId' value='" + idPlace + "'>" +
                       "<input type='submit' value='Enviar'>" +
                       "</form>";
            return new ContentResult
            {
                Content = html,
                ContentType = "text/html"
            };
        }

        form input[type=""submit""] {
            width: auto;
            background-color: #476930;
            color: #FFF;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
            font-family: 'Bitter', serif;
            font-optical-sizing: auto;
            border-radius: 20px;
        }

        form input[type=""submit""]:hover {
            background-color: #8CC366;
        }

        .star-rating-container {
            display: flex;
            align-items: center;
            justify-content: space-between;
            width: 100%;
        }

        .star-rating {
            display: flex;
            flex-direction: row-reverse;
            justify-content: center;
            font-size: 2em;
            min-width: 40%;
        }

        .star-rating input {
            display: none;
        }

        .star-rating label {
            color: #ccc;
            cursor: pointer;
            transition: color 0.2s;
        }

        .star-rating input:checked ~ label,
        .star-rating label:hover,
        .star-rating label:hover ~ label {
            color: #F67924;
        }

        .star-rating input:checked + label:hover,
        .star-rating input:checked + label:hover ~ label,
        .star-rating label:hover ~ input:checked ~ label {
            color: #F67924;
        }

        .end {
            font-weight: bold;
            color: #F67924;
            font-family: 'Bitter', serif;
            font-optical-sizing: auto;
            display: flex;
            justify-content: space-between;
            margin: 5%;
            padding: 0 10%;
        }

        .backk, .index, .create {
            text-align: left;
            color: #476930;
            text-decoration: none;
            font-weight: bold;
            font-family: 'Bitter', serif;
            font-optical-sizing: auto;
        }

        .create-review {
            text-align: center;
            margin-bottom: 20px;
        }
    ";

			var html = new StringBuilder();
			html.Append($"<style>{css}</style>");
			html.Append("<h1>Crear reseña</h1>");
			html.Append("<form id='createReviewForm'>");
			html.Append("<div class='star-rating-container'>");
			html.Append("<label for='Rate'>Calificación:</label>");
			html.Append("<div class='star-rating'>");
			html.Append("<input type='radio' id='star5' name='Rate' value='5'><label for='star5'>&#9733;</label>");
			html.Append("<input type='radio' id='star4' name='Rate' value='4'><label for='star4'>&#9733;</label>");
			html.Append("<input type='radio' id='star3' name='Rate' value='3'><label for='star3'>&#9733;</label>");
			html.Append("<input type='radio' id='star2' name='Rate' value='2'><label for='star2'>&#9733;</label>");
			html.Append("<input type='radio' id='star1' name='Rate' value='1'><label for='star1'>&#9733;</label>");
			html.Append("</div>");
			html.Append("</div>");
			html.Append("<label for='Comment'>Comentario:</label>");
			html.Append("<textarea id='Comment' maxlength='200' name='Comment' rows='4' cols='50'></textarea>");
			html.Append("<input type='hidden' name='PlaceId' value='" + idPlace + "'>");
			html.Append("<input type='submit' value='Enviar'>");
			html.Append("</form>");
			html.Append($"<div class='end'><a href='#' onclick='showPlaceInfo({idPlace})' class='backk'>Volver al lugar</a>");
			html.Append("<a href='/Home/Index' class='index'>Volver al inicio</a></div>");

			return new ContentResult
			{
				Content = html.ToString(),
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

			var css = @"
        h2 {
            margin-top: 5%;
            text-align: center;
            color: #476930;
            font-family: 'Bitter', serif;
            font-optical-sizing: auto;
            font-weight: bold;
        }
        form {
            display: flex;
            flex-direction: column;
            align-items: center;
            padding: 10%;
            width: 70%;
            margin: auto;
        }
        form label, form input {
            display: block;
            margin-bottom: 10px;
            width: 100%;
            text-align: left;
            font-weight: bold;
            font-family: 'Inter', sans-serif;
        }
        form textarea {
            display: block;
            margin-bottom: 10px;
            width: 100%;
            text-align: left;
            font-family: 'Inter', sans-serif;
        }
        form input[type=""submit""] {
            width: auto;
            background-color: #476930;
            color: #FFF;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
            font-family: 'Bitter', serif;
            font-optical-sizing: auto;
            border-radius: 20px;
        }
        form input[type=""submit""]:hover {
            background-color: #8CC366;
        }
        .star-rating-container {
            display: flex;
            align-items: center;
            justify-content: space-between;
            width: 100%;
        }
        .star-rating {
            display: flex;
            flex-direction: row-reverse;
            justify-content: center;
            font-size: 2em;
            min-width: 40%;
        }
        .star-rating input {
            display: none;
        }
        .star-rating label {
            color: #ccc;
            cursor: pointer;
            transition: color 0.2s;
        }
        .star-rating input:checked ~ label,
        .star-rating label:hover,
        .star-rating label:hover ~ label {
            color: #F67924;
        }
        .star-rating input:checked + label:hover,
        .star-rating input:checked + label:hover ~ label,
        .star-rating label:hover ~ input:checked ~ label {
            color: #F67924;
        }
        .end {
            font-weight: bold;
            color: #F67924;
            font-family: 'Bitter', serif;
            font-optical-sizing: auto;
            display: flex;
            justify-content: space-between;
            margin: 5%;
            padding: 0 10%;
        }
        .backk, .index {
            text-align: left;
            color: #476930;
            text-decoration: none;
            font-weight: bold;
            font-family: 'Bitter', serif;
            font-optical-sizing: auto;
        }
    ";

			var html = new StringBuilder();
			html.Append($"<style>{css}</style>");
			html.Append("<h2>Actualizar reseña</h2>");
			html.Append("<form id='updateReviewForm'>");
			html.Append("<div class='star-rating-container'>");
			html.Append("<label for='Rate'>Calificación:</label>");
			html.Append("<div class='star-rating'>");
			for (int i = 5; i >= 1; i--)
			{
				html.Append($"<input type='radio' id='star{i}' name='Rate' value='{i}' {(review.Rate == i ? "checked" : "")}><label for='star{i}'>&#9733;</label>");
			}
			html.Append("</div></div>");
			html.Append("<label for='Comment'>Comentario:</label>");
			html.Append($"<textarea id='Comment' name='Comment' rows='4' cols='50'>{review.Comment}</textarea>");
			html.Append($"<input type='hidden' name='IdReview' value='{review.IdReview}'>");
			html.Append($"<input type='hidden' name='PlaceId' value='{review.PlaceId}'>");
			html.Append("<input type='submit' value='Actualizar'>");
			html.Append("</form>");
			html.Append($"<div class='end'><a href='#' onclick='showPlaceInfo({review.PlaceId})' class='backk'>Volver al lugar</a>");
			html.Append("<a href='/Home/Index' class='index'>Volver al inicio</a></div>");

			return new ContentResult
			{
				Content = html.ToString(),
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