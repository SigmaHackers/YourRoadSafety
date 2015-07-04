(function () {
    'use strict';

    var app = angular.module('YourRoadSafety', []);

    app.controller('MainCtrl', ['$scope', '$http', function ($scope, $http) {
        $scope.name = 'World';
        $scope.points = [];

        var apiRootPath = "//localhost:50129/api";

        function updateMap() {
            var tiles = L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
                maxZoom: 18,
                attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors, Points &copy 2012 LINZ'
            }),
                latlng = L.latLng(-37.81368, 145.12477);
            //latlng = L.latLng(-38.1482595,144.3629658);
            //latlng = L.latLng(-37.79, 175.27);

            var map = L.map('map', { center: latlng, zoom: 13, layers: [tiles] });

            var progress = document.getElementById('progress');
            var progressBar = document.getElementById('progress-bar');

            function updateProgressBar(processed, total, elapsed, layersArray) {
                if (elapsed > 1000) {
                    // if it takes more than a second to load, display the progress bar:
                    progress.style.display = 'block';
                    progressBar.style.width = Math.round(processed / total * 100) + '%';
                }

                if (processed === total) {
                    // all markers processed - hide the progress bar:
                    progress.style.display = 'none';
                }
            }

            var markers = L.markerClusterGroup({ chunkedLoading: true, chunkProgress: updateProgressBar });

            var markerList = [];

            for (var i = 0; i < $scope.points.length; i++) {
                var a = $scope.points[i];
                var title = a.Title;
                var marker = L.marker(L.latLng(a.Latitude, a.Longitude), { title: title });
                marker.bindPopup(title);
                markerList.push(marker);
            }

            //console.log('start clustering: ' + window.performance.now());

            markers.addLayers(markerList);
            map.addLayer(markers);

        };

        $http.get(apiRootPath + '/CrashData').then(function (response) {
            $scope.points = response.data;
            updateMap();

        }).catch(function (err) {
            $scope.points = err;
            alert(err);
        });
    }]);

}());
