/// <reference path="../View/Partial Views/ngAbuse.html" />
'use strict';

angular.module('MainModule', ['ngRoute', 'Module1']).config(['$routeProvider', function ($routeProvider) {
 
    $routeProvider.when('/ngAbuse', {
        templateUrl: 'Partial Views/ngAbuse.html',
        controller: 'Controller1'
    })
        .when('/pictureView', {
            templateUrl: 'Partial Views/pictureView.html',
            controller: 'Controller1'
        })
        .when('/videoView', {
            templateUrl: 'Partial Views/videoView.html',
            controller: 'Controller1'
        }).otherwise({ redirectTo: '/' });
}]);