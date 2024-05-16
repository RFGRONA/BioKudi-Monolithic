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

$(document).on('submit', '#createReviewForm', function (event) {
    event.preventDefault();
    placeId = $(this).find('input[name="PlaceId"]').val(); 
    var formData = $(this).serialize();
    $.ajax({
        url: '/Map/CreateReview',
        method: 'POST',
        data: formData,
        success: function (data) {
            showPlaceInfo(placeId);
        },
        error: function (err) {
            console.error('Error al cargar el formulario de creación de reseñas:', err);
        }
    });
});

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

$(document).on('submit', '#updateReviewForm', function (event) {
    event.preventDefault();
    placeId = $(this).find('input[name="PlaceId"]').val();
    var formData = $(this).serialize();
    $.ajax({
        url: '/Map/UpdateReview',
        method: 'POST',
        data: formData,
        success: function (data) {
            showPlaceInfo(placeId);
        },
        error: function (err) {
            console.error('Error al cargar el formulario de actualizar reseña:', err);
        }
    });
});

function deleteReview(reviewId, placeId) {
    $.ajax({
        url: '/Map/DeleteReview?idReview=' + reviewId,
        method: 'POST',
        success: function (data) {
            showPlaceInfo(placeId); 
        },
        error: function (err) {
            console.error('Error al eliminar la reseña:', err);
        }
    });
}

