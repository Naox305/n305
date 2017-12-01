"use strict";

MainModule.controller('MenuCTRL', ['$scope', '$rootScope', '$window' ,'globalFactory', function ($scope, $rootScope, $window, globalFactory) {

    this.menuItems = menuJSON;

    $rootScope.showHomeButton = true;

    this.GotoUrl = function (url) {

        $window.location.href = url;

    }

    //this.showHomeButton = globalFactory.show;
}]);