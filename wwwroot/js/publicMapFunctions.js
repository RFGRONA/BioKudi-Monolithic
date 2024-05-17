function showPlaceInfo(placeId) {
    $.ajax({
        url: '/Map/InfoMap?idPlace=' + placeId,
        method: 'GET',
        success: function (data) {
            $('#info').html(data);
        },
        error: function (err) {
            console.error('Error al obtener informaci�n del lugar:', err);
        }
    });
}
function showReviews(placeId) {
    $.ajax({
        url: '/Map/ReviewsPlace?idPlace=' + placeId,
        method: 'GET',
        success: function (data) {
            $('#info').html(data);
        },
        error: function (err) {
            console.error('Error al obtener reseñas del lugar:', err);
        }
    });
}