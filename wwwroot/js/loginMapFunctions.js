var placeId;

function showPlaceInfo(placeId) {
    $.ajax({
        url: '/Map/InfoMapUser?idPlace=' + placeId,
        method: 'GET',
        success: function (data) {
            $('#info').html(data);
        },
        error: function (err) {
            console.error('Error al obtener información del lugar:', err);
        }
    });
}

function showReviews(placeId, userId) {
    $.ajax({
        url: '/Map/Reviews?idPlace=' + placeId + '&idUser=' + userId,
        method: 'GET',
        success: function (data) {
            $('#info').html(data);
        },
        error: function (err) {
            console.error('Error al obtener reseñas del lugar:', err);
        }
    });
}

function CreateReview(placeId) {
    $.ajax({
        url: '/Map/CreateReview?idPlace=' + placeId,
        method: 'GET',
        success: function (data) {
            $('#info').html(data);
        },
        error: function (err) {
            console.error('Error al cargar el formulario de creación de reseñas:', err);
        }
    });
}

function updateReview(reviewId) {
    $.ajax({
        url: '/Map/UpdateReview?idReview=' + reviewId,
        method: 'GET',
        success: function (data) {
            $('#info').html(data);
        },
        error: function (err) {
            console.error('Error al cargar el formulario de actualizar reseña:', err);
        }
    });
}

