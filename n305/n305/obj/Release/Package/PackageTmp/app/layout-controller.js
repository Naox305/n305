

MainModule.controller('LayoutCTRL', ['$scope','$rootScope', '$window', 'globalFactory', function ($scope, $rootScope, $window, globalFactory) {

    //this.menuItems = menuJSON;
    _this = this;

    $rootScope.showHomeButtonmn = false;

    //this.showHomeButton = globalFactory.show;
    this.makePulse = 'pulsating';

    this.GotoUrl = function (url) {

        globalFactory.show = true;

        $rootScope.showHomeButton = true;

        $window.location.href = url;
      

    }

   
}]);