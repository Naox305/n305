"use strict";

MainModule.controller('GalleryCTRL', ['$scope', '$rootScope', '$window', 'globalFactory', function ($scope, $rootScope, $window, globalFactory) {

    this.galleryItems = galleryJSON;

    $rootScope.showHomeButton = true;

    this.GotoUrl = function (url) {

        $window.location.href = url;

    }

}]);