"use strict";

angular.module('Module1', []).controller('Controller1', ['$scope', function ($scope) {

    var initialUrl = "/AngularJS/View/Index.html#/";
    var noView = "PRESS";


    $scope.pictureUri = "http://www.wallpaperseek.com/wallpapers/7724_1024.jpg";
    $scope.videoUri = "http://www.siplec.com/sites/default/files/videos/oceans-clip.mp4";
    $scope.viewName = noView;
    var partialViewsURNs = ['ngAbuse', 'pictureView', 'videoView'];
    var localCount = 0;
    $scope.blankThis = blankThis;

    $scope.navigateToUrl = function (event) {
        window.location = initialUrl + partialViewsURNs[localCount];
        $scope.viewName = partialViewsURNs[localCount];
        if (localCount >= partialViewsURNs.length-1)
        {
            localCount = 0;
        } else {
            localCount = localCount + 1;
        }
    }

    $scope.addToBlankThis = function (event) {
        blankThis.push({blank:" " });
    }
}]);