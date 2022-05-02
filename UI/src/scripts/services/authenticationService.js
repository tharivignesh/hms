'use strict';

var authenticationService = angular.module('authenticationService', [])
    .service('authenticationService', function ($rootScope) {
    this.Login = function (userName, password) {
        return fetchWrapper(`https://localhost:44375/api/Account`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ userName: userName, password: password })
        })
    }

    this.SetCredentials = function (userData) {
        $rootScope.token = userData.LoginHash
        $rootScope.isAdmin = userData.IsAdmin === 1
        $rootScope.isUser = userData.IsAdmin !== 1
        $rootScope.User = userData
    };

    this.ClearCredentials = function () {
        $rootScope.token = null;
    };
});