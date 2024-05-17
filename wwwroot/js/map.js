var map = L.map('map').setView([4.863333, -74.052778], 9);
L.tileLayer('https://cartodb-basemaps-{s}.global.ssl.fastly.net/light_all/{z}/{x}/{y}.png', {
    maxZoom: 19,
    attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
}).addTo(map);


var cundinamarcaLayer = L.geoJSON(null, {
  style: function(feature) {
    return {
      stroke: false,
      color: '#6cfe71',
      fillOpacity: 0.2
    };
  }
});

fetch('/js/cundinamarca.geojson')
.then(function(response) {
  return response.json();
})
.then(function(data) {
  cundinamarcaLayer.addData(data);
  cundinamarcaLayer.addTo(map);
  var bounds = cundinamarcaLayer.getBounds();
  map.setMaxBounds(bounds);
  map.on('drag', function() {
      map.panInsideBounds(bounds, { animate: false });
  });
});
