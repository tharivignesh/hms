'use strict';

var hmsApp = angular.module(
  'hmsApp', [
  'ngRoute',
  'ngSanitize',
  'authenticationService',
  'hmsService'
], function ($locationProvider) {
  $locationProvider.html5Mode({
    enabled: false,
    requireBase: false
  });
});

hmsApp.config(function ($routeProvider) {
  $routeProvider
    .when('/login', {
      templateUrl: 'views/loginView.html', 
      controller: 'loginController'
    })
    .when('/home', {
      templateUrl: 'views/roomsView.html', // list of rooms
      controller: 'mainController'
    })
    .when('/bookings', {
      templateUrl: 'views/bookingsView.html',
      controller: 'bookingsController'
    })
    .when('/mybookings', {
      templateUrl: 'views/myBookingsView.html',
      controller: 'mybookingsController'
    })
    .when('/unauthorized', {
      templateUrl: 'unauthorized.html',
    })
    .otherwise({
      redirectTo: '/login'
    });
});

hmsApp.run(['$rootScope', function ($rootScope) {
  $rootScope.errorMessage = undefined;
  $rootScope.loading = false;
  $rootScope.authorized = false;
}]);

hmsApp.directive('onEnter', function () {
  var linkFn = function (scope, element, attrs) {
    element.bind("keypress", function (event) {
      if (event.which === 13) {
        scope.$apply(function () {
          scope.$eval(attrs.onEnter);
        });
        event.preventDefault();
      }
    });
  };
  return {
    link: linkFn
  };
});