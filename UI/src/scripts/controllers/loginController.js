'use strict';

hmsApp.controller('loginController', function loginController($scope, $rootScope, authenticationService) {
  $rootScope.authorized = false
  $scope.error = undefined
  authenticationService.ClearCredentials();
  $rootScope.loading = false

  $scope.login = function () {
    $rootScope.loading = true
    authenticationService.Login($scope.username, $scope.password).then((response) => {
      if (response) {
        authenticationService.SetCredentials(response);
        if (response.IsAdmin === 1)
          window.location.replace('#!/home');
        else
          window.location.replace('#!/mybookings');
      } else {
        $scope.error = "Login failed";
        $rootScope.loading = false
      }
      $scope.$apply();
    }).catch((err) => {
      $scope.error = "Login failed";
      $rootScope.loading = false
      $scope.$apply();
    });

  };

});