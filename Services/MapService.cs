using BioKudi.dto;
using BioKudi.Models;
using BioKudi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
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
                            margin: 0;
                            padding: 0;
                            overflow: hidden;
                        }

                        html, body {
                            height: 100%;
                            width: 100%;
                        }

                        table {
                            margin: 1%;
                            width: 98%;
                        }

                        td {
                            padding: 5px;
                            word-wrap: break-word; 
                        }

                        .img-container {
                            width: 100%;
                            text-align: center;
                        }

                        img {
                            min-width: 50%;
                            max-width: 100%;
                            height: auto;
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
                            color: #476930;
                            font-size: 30px;
                            vertical-align: top;
                        }

                        .iconn, .activity, .description {
                            text-align: left;
                            vertical-align: top;
                            font-size: 24px;
                            color: #476930;
                            margin-bottom: 2%;
                            font-family: 'Bitter', serif;
                            font-optical-sizing: auto;
                        }

                        .rating, .end {
                            display: flex;
                            text-align: left;
                            font-weight: bold;
                            vertical-align: top;
                            font-size: 28px;
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
                            font-size: 28px;
                            align-content: center;
                            text-align: center;
                        }

                        .info-container {
                            height: 100%;
                            width: 100%;
                            overflow-y: auto;
                        }

                        .pagina, .volver, .linkre {
                            color: #F67924;
                            text-decoration: none;
                            margin: 0 10px;
                            text-align: center;      
                        }

                        .button-container {
                            display: flex;
                            justify-content: center; 
                            gap: 20px; 
                            margin-top: 20px; 
                        }

                        .button-container .pagina, 
                        .button-container .volver, 
                        .button-container .linkre {
                            font-size: 24px; /* Tamaño de fuente base para los botones */
                        }

                        @media (max-width: 1200px) {
                            .button-container .pagina, 
                            .button-container .volver, 
                            .button-container .linkre {
                                font-size: 18px;
                            }
                        }

                        @media (max-width: 992px) {
                            .button-container .pagina, 
                            .button-container .volver, 
                            .button-container .linkre {
                                font-size: 16px;
                            }
                        }

                        @media (max-width: 768px) {
                            .button-container .pagina, 
                            .button-container .volver, 
                            .button-container .linkre {
                                font-size: 14px;
                            }
                        }

                        @media (max-width: 576px) {
                            .button-container .pagina, 
                            .button-container .volver, 
                            .button-container .linkre {
                                font-size: 12px;
                            }
                        }
                        ";

			var html = new StringBuilder();

			html.Append("<head>").Append(head).Append("</head><style>").Append(css).Append("</style>")
				.Append("<table>")
				.Append("<tr>")
				.Append("<td class=\"image\" colspan=\"2\">");

			if (place.PictureData.Any())
			{
				var firstPicture = place.PictureData.FirstOrDefault();
				html.Append("<img src=\"").Append(WebUtility.HtmlEncode(firstPicture.Link)).Append("\" ")
					.Append("alt=\"").Append(WebUtility.HtmlEncode(firstPicture.Name)).Append("\" />");
			}
			else
			{
				html.Append("<img src=\"https://cloudfront-us-east-1.images.arcpublishing.com/semana/UNB4UJO4OZEQZGEYGL6YQE74NM.jpg\" alt=\"No image\" />");
			}

			html.Append("</td>")
				.Append("</tr>")
				.Append("<tr>")
				.Append("<td class=\"title\" colspan=\"2\">")
				.Append("<div class=\"titulo\">").Append(WebUtility.HtmlEncode(place.NamePlace)).Append("</div>")
				.Append("</td>")
				.Append("</tr>")
				.Append("<tr>")
				.Append("<td class=\"icon\"><i class=\"fa-solid fa-location-dot\"></i></td>")
				.Append("<td class=\"iconn\">").Append(WebUtility.HtmlEncode(place.Address)).Append("</td>")
				.Append("</tr>")
				.Append("<tr>")
				.Append("<td class=\"icon\"><i class=\"fa-solid fa-person-hiking\"></i></td>")
				.Append("<td class=\"activity\">");

			var activities = string.Join(", ", place.ActivityData.Select(a => WebUtility.HtmlEncode(a.Type)));
			html.Append(activities);

			html.Append("</td>")
				.Append("</tr>")
				.Append("<tr>")
				.Append("<td class=\"icon\"><i class=\"fa-solid fa-file-lines\"></i></td>")
				.Append("<td class=\"description\">").Append(WebUtility.HtmlEncode(place.Description)).Append("</td>")
				.Append("</tr>")
				.Append("<tr>")
				.Append("<td class=\"icon\"><i class=\"fa-solid fa-star-half-stroke\"></i></td>")
                .Append("<td class=\"rating\"><div class=\"ratingdiv\">").Append(WebUtility.HtmlEncode(place.Rating.ToString("0.0"))).Append(" / 5.0</div></td>")
                .Append("</tr>")
				.Append("<tr>")
				.Append("<td class=\"iconWeb\"><i class=\"fa-solid fa-arrow-up-right-from-square\"></i></td>")
				.Append("<td class=\"end\">")
				.Append("<div class=\"button-container\">")
				.Append("<a href=\"").Append(WebUtility.HtmlEncode(place.Link)).Append("\" class=\"pagina\">Pagina Web</a>")
				.Append("<a href='#' onclick='showReviews(").Append(place.IdPlace).Append(")' class=\"linkre\">Ver reseñas</a>")
				.Append("<a href=\"/Home/Index\" class=\"volver\">Volver al inicio</a>")
				.Append("</div>")
				.Append("</td>")
				.Append("</tr>")
				.Append("</table>");

			return new ContentResult
			{
				Content = html.ToString(),
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
			var head = @"
                        <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css"">
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
                            margin: 0;
                            padding: 0;
                            overflow: hidden;
                        }

                        html, body {
                            height: 100%;
                            width: 100%;
                        }

                        table {
                            margin: 1%;
                            width: 98%;
                        }

                        td {
                            padding: 5px;
                            word-wrap: break-word; 
                        }

                        .img-container {
                            width: 100%;
                            text-align: center;
                        }

                        img {
                            min-width: 50%;
                            max-width: 100%;
                            height: auto;
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
                            color: #476930;
                            font-size: 30px;
                            vertical-align: top;
                        }

                        .iconn, .activity, .description {
                            text-align: left;
                            vertical-align: top;
                            font-size: 24px;
                            color: #476930;
                            margin-bottom: 2%;
                            font-family: 'Bitter', serif;
                            font-optical-sizing: auto;
                        }

                        .rating, .end {
                            display: flex;
                            text-align: left;
                            font-weight: bold;
                            vertical-align: top;
                            font-size: 28px;
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
                            font-size: 28px;
                            align-content: center;
                            text-align: center;
                        }

                        .info-container {
                            height: 100%;
                            width: 100%;
                            overflow-y: auto;
                        }

                        .pagina, .volver, .linkre {
                            color: #F67924;
                            text-decoration: none; 
                            margin: 0 10px; 
                            text-align: center;
                        }

                        .button-container {
                            display: flex;
                            justify-content: center; 
                            gap: 20px; 
                            margin-top: 20px; 
                        }

                        .button-container .pagina, 
                        .button-container .volver, 
                        .button-container .linkre {
                            font-size: 24px; /* Tamaño de fuente base para los botones */
                        }

                        @media (max-width: 1200px) {
                            .button-container .pagina, 
                            .button-container .volver, 
                            .button-container .linkre {
                                font-size: 18px;
                            }
                        }

                        @media (max-width: 992px) {
                            .button-container .pagina, 
                            .button-container .volver, 
                            .button-container .linkre {
                                font-size: 16px;
                            }
                        }

                        @media (max-width: 768px) {
                            .button-container .pagina, 
                            .button-container .volver, 
                            .button-container .linkre {
                                font-size: 14px;
                            }
                        }

                        @media (max-width: 576px) {
                            .button-container .pagina, 
                            .button-container .volver, 
                            .button-container .linkre {
                                font-size: 12px;
                            }
                        }
                        ";

			var html = new StringBuilder();

			html.Append("<head>").Append(head).Append("</head><style>").Append(css).Append("</style>")
				.Append("<table>")
				.Append("<tr>")
				.Append("<td class=\"image\" colspan=\"2\">");

			if (place.PictureData.Any())
			{
				var firstPicture = place.PictureData.FirstOrDefault();
				html.Append("<img src=\"").Append(WebUtility.HtmlEncode(firstPicture.Link)).Append("\" ")
					.Append("alt=\"").Append(WebUtility.HtmlEncode(firstPicture.Name)).Append("\" />");
			}
			else
			{
				html.Append("<img src=\"https://cloudfront-us-east-1.images.arcpublishing.com/semana/UNB4UJO4OZEQZGEYGL6YQE74NM.jpg\" alt=\"No image\" />");
			}

			html.Append("</td>")
				.Append("</tr>")
				.Append("<tr>")
				.Append("<td class=\"title\" colspan=\"2\">")
				.Append("<div class=\"titulo\">").Append(WebUtility.HtmlEncode(place.NamePlace)).Append("</div>")
				.Append("</td>")
				.Append("</tr>")
				.Append("<tr>")
				.Append("<td class=\"icon\"><i class=\"fa-solid fa-location-dot\"></i></td>")
				.Append("<td class=\"iconn\">").Append(WebUtility.HtmlEncode(place.Address)).Append("</td>")
				.Append("</tr>")
				.Append("<tr>")
				.Append("<td class=\"icon\"><i class=\"fa-solid fa-person-hiking\"></i></td>")
				.Append("<td class=\"activity\">");

			var activities = string.Join(", ", place.ActivityData.Select(a => WebUtility.HtmlEncode(a.Type)));
			html.Append(activities);

			html.Append("</td>")
				.Append("</tr>")
				.Append("<tr>")
				.Append("<td class=\"icon\"><i class=\"fa-solid fa-file-lines\"></i></td>")
				.Append("<td class=\"description\">").Append(WebUtility.HtmlEncode(place.Description)).Append("</td>")
				.Append("</tr>")
				.Append("<tr>")
				.Append("<td class=\"icon\"><i class=\"fa-solid fa-star-half-stroke\"></i></td>")
                .Append("<td class=\"rating\"><div class=\"ratingdiv\">").Append(WebUtility.HtmlEncode(place.Rating.ToString("0.0"))).Append(" / 5.0</div></td>")
                .Append("</tr>")
				.Append("<tr>")
				.Append("<td class=\"iconWeb\"><i class=\"fa-solid fa-arrow-up-right-from-square\"></i></td>")
				.Append("<td class=\"end\">")
				.Append("<div class=\"button-container\">")
				.Append("<a href=\"").Append(WebUtility.HtmlEncode(place.Link)).Append("\" class=\"pagina\">Pagina Web</a>")
				.Append("<a href='#' onclick='showReviews(").Append(place.IdPlace).Append(", ").Append(idUser).Append(")' class=\"linkre\">Ver reseñas</a>")
				.Append("<a href=\"/Home/Index\" class=\"volver\">Volver al inicio</a>")
				.Append("</div>")
				.Append("</td>")
				.Append("</tr>")
				.Append("</table>");

			return new ContentResult
			{
				Content = html.ToString(),
				ContentType = "text/html"
			};
		}

        // Bring all reviews for non-logged users. 
        public ContentResult GetReviews(int idPlace)
        {
            var reviews = reviewRepo.GetReviewPlace(idPlace);
            var head = @"
                <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css"">
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
                margin: 0;
                padding: 0;
                overflow: hidden;
            }

            html, body {
                height: 100%;
                width: 100%;
            }

            .info-container {
                height: 100%;
                width: 100%;
                overflow-y: auto;
            }

            table {
                margin: 1%;
                min-width: 95%;
                table-layout: fixed;
                word-wrap: break-word;
                word-break: break-all;
                margin-bottom: 2%;
            }

            colgroup col:first-child {
                width: 20%;
            }

            colgroup col:not(:first-child) {
                width: 80%;
            }

            h1 {
                text-align: center;
                color: #476930;
                font-family: 'Bitter', serif;
                font-optical-sizing: auto;
                font-weight: bold;
            }

            p {
                text-align: center;
            }

            td, th {
                padding: 3px;
                vertical-align: top;    
            }

            .rate {
                text-align: center;
                font-weight: bold;
                font-size: 28px;
                color: #F67924;
                font-family: 'Bitter', serif;
                font-optical-sizing: auto;
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

            .backk {
                text-align: left;
                color: #476930;
                text-decoration: none;
            }

            .index {
                text-align: right;
                color: #476930;
                text-decoration: none;  
            }

            .user {
                text-align: left;
                font-weight: bold;
                font-size: 18px;
                font-family: 'Inter', sans-serif;
            }

            .comment {
                text-align: left;
                font-size: 17px;
                font-family: 'Inter', sans-serif;
            }

            @media (max-width: 1200px) {
                .rate {
                    font-size: 24px;
                }

                .user, .end {
                    font-size: 18px;
                }
            }

            @media (max-width: 992px) {
                .rate {
                    font-size: 20px;
                }

                .user, .end {
                    font-size: 16px;
                }
            }

            @media (max-width: 768px) {
                .rate {
                    font-size: 18px;
                }

                .user, .end {
                    font-size: 14px;
                }
            }

            @media (max-width: 576px) {
                .rate {
                    font-size: 16px;
                }

                .user, .end {
                    font-size: 12px;
                }
            }";
            var html = new StringBuilder();
            html.Append($"<head>{head}</head>");
            html.Append($"<style>{css}</style>");
            html.Append("<div class='info-container'>");
            html.Append("<h1>Reseñas</h1>");

            if (reviews.Any())
            {
                html.Append("<table><colgroup><col style='width: 20%'><col style='width: 80%'></colgroup>");
                foreach (var review in reviews)
                {
                    html.Append($"<tr><td rowspan='2'><div class='rate'>&#9733; {WebUtility.HtmlEncode(review.Rate.ToString())} / 5</div></td>");
                    html.Append($"<td class='user'>{WebUtility.HtmlEncode(review.UserName)}</td></tr>");
                    if (!string.IsNullOrWhiteSpace(review.Comment))
                    {
                        html.Append($"<tr><td class='comment'>{WebUtility.HtmlEncode(review.Comment)}</td></tr>");
                    }
                    html.Append("<tr><td></td></tr>");
                }
                html.Append("</table>");
            }
            else
            {
                html.Append("<p>No hay reseñas todavía.<br>Si desea dejar una reseña, por favor inicie sesión.</p>");
            }

            html.Append($"<div class='end'><a href='#' onclick='showPlaceInfo({idPlace})' class='backk'>Volver al lugar</a>");
            html.Append("<a href='/Home/Index' class='index'>Volver al inicio</a></div>");
            html.Append("</div>"); // Cierre del contenedor info-container

            return new ContentResult
            {
                Content = html.ToString(),
                ContentType = "text/html"
            };
        }

        // Bring all the reviews, the first being those of the logged in user
        public ContentResult GetReviews(int idPlace, int idUser)
		{
			var reviews = reviewRepo.GetReviewUser(idPlace, idUser);
			var head = @"
                        <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css"">
                        <link rel=""preconnect"" href=""https://fonts.googleapis.com"">
                        <link rel=""preconnect"" href=""https://fonts.gstatic.com"" crossorigin>
                        <link href=""https://fonts.googleapis.com/css2?family=Bitter:ital,wght@0,100..900;1,100..900&display=swap"" rel=""stylesheet"">
                        <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js""></script>
                        <script src=""https://cdn.jsdelivr.net/npm/sweetalert2@10""></script>
                        <link rel=""preconnect"" href=""https://fonts.googleapis.com"">
                        <link rel=""preconnect"" href=""https://fonts.gstatic.com"" crossorigin>
                        <link href=""https://fonts.googleapis.com/css2?family=Asul:wght@400;700&family=Inter:wght@100..900&display=swap"" rel=""stylesheet"">
                        <link rel=""stylesheet"" href=""~/lib/font-awesome/css/all.min.css"" />";
			var css = @"table {
                margin: 1%;
                min-width: 95%;
                table-layout: fixed;
                word-wrap: break-word;
                word-break: break-all;
                margin-bottom: 2%;
                }
                colgroup col:first-child {
                    width: 20%;
                }
                colgroup col:not(:first-child) {
                    width: 80%;
                }
                h1 {
                    text-align: center;
                    color: #476930;
                    font-family: 'Bitter', serif;
                    font-optical-sizing: auto;
                    font-weight: bold;
                }
                p {
                    text-align: center;
                }
                body {
                    background-color: #FEECD6;
                }
                td, th {
                    padding: 3px;
                    vertical-align: top;
                }
                .rate {
                    text-align: center;
                    font-weight: bold;
                    font-size: 28px;
                    color: #F67924;
                    font-family: 'Bitter', serif;
                    font-optical-sizing: auto;
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
                    color: #476930;
                    text-decoration: none;
                }
                .create-review {
                    text-align: center;
                    margin-bottom: 20px;
                }
                .user {
                    text-align: left;
                    font-weight: bold;
                    font-size: 18px;
                    font-family: 'Inter', sans-serif;
                }
                .comment {
                    text-align: left;
                    font-size: 17px;
                    font-family: 'Inter', sans-serif;
                }
                .review-buttons {
                    text-align: center;
                    margin-top: 10px;
                }
                @media (max-width: 1200px) {
                    .rate {
                        font-size: 24px;
                    }
                    .user, .end {
                        font-size: 18px;
                    }
                }
                @media (max-width: 992px) {
                    .rate {
                        font-size: 20px;
                    }
                    .user, .end {
                        font-size: 16px;
                    }
                }
                @media (max-width: 768px) {
                    .rate {
                        font-size: 18px;
                    }
                    .user, .end {
                        font-size: 14px;
                    }
                }
                @media (max-width: 576px) {
                    .rate {
                        font-size: 16px;
                    }
                    .user, .end {
                        font-size: 12px;
                    }
                }
                .create {
                    text-align: center;
                    color: #476930;
                    text-decoration: none;
                    font-weight: bold;
                    font-family: 'Bitter', serif;
                    font-optical-sizing: auto;
                    display: block;
                    margin-bottom: 20px;
                }
                .user-actions {
                    float: right;
                    margin-right: 10px;
                    font-size: 18px;
                    cursor: pointer;
                    color: #F67924;
                }
                .user-actions .update-icon {
                    margin-right: 10px;
                }
                .info-container {
                    height: 100%;
                    width: 100%;
                    overflow-y: auto;
                }";

			var html = new StringBuilder();
			html.Append($"<head>{head}</head>");
			html.Append($"<style>{css}</style>");
            html.Append("<div class='info-container'>");
            html.Append("<h1>Reseñas</h1>");
			html.Append($"<div class='create-review'><a href='#' onclick='CreateReview({idPlace})' class='create'>Crear reseña</a></div>");

			if (reviews.Any())
			{
				html.Append("<table><colgroup><col style='width: 20%'><col style='width: 80%'></colgroup>");
				foreach (var review in reviews)
				{
					html.Append($"<tr><td rowspan='2'><div class='rate'>&#9733; {WebUtility.HtmlEncode(review.Rate.ToString())} / 5</div></td>");
					html.Append($"<td class='user'>{WebUtility.HtmlEncode(review.UserName)}");

					if (review.UserId == idUser)
					{
						html.Append($"<span class='user-actions'><i class='fa-solid fa-pen-to-square' onclick='updateReview({review.IdReview})'></i>");
						html.Append($"<i class='update-icon'></i><i class='fa-solid fa-trash-can' onclick='deleteReview({review.IdReview}, {idPlace})'></i></span>");
					}

					html.Append("</td></tr>");

					if (!string.IsNullOrWhiteSpace(review.Comment))
					{
						html.Append($"<tr><td class='comment'>{WebUtility.HtmlEncode(review.Comment)}</td></tr>");
					}
					html.Append("<tr><td></td></tr>");
				}
				html.Append("</table>");
			}
			else
			{
				html.Append("<p>No hay reseñas todavía. ¡Sé el primero en dejar una!</p>");
			}

			html.Append($"<div class='end'><a href='#' onclick='showPlaceInfo({idPlace})' class='backk'>Volver al lugar</a>");
			html.Append("<a href='/Home/Index' class='index'>Volver al inicio</a></div>");
            html.Append("</div>");

            return new ContentResult
			{
				Content = html.ToString(),
				ContentType = "text/html"
			};
		}

		public ContentResult CreateReviewForm(int idPlace)
		{
			var css = @"
                h1 {
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