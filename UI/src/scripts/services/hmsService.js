'use strict';

var hmsService = angular.module('hmsService', [])
  .service('hmsService', function ($rootScope) {

    this.authorization = async function () {

      if ($rootScope.token) {
        $rootScope.authorized = true
      } else {
        window.location.replace('#!/login');
        return;
      }
    }

    this.getRooms = () => {
      return fetchWrapper(`https://localhost:44375/api/Rooms`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${$rootScope.User.LoginHash}`
        }
      })
    }

    this.addRoom = function (newRoom) {
      return fetchWrapper(`https://localhost:44375/api/Rooms`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${$rootScope.User.LoginHash}`
        },
        body: JSON.stringify(newRoom)
      })
    }

    this.getBookings = () => {
      return fetchWrapper(`https://localhost:44375/api/Bookings`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${$rootScope.User.LoginHash}`
        }
      })
    }

    this.getMyBookings = (userId) => {
      return fetchWrapper(`https://localhost:44375/api/Bookings?userId=${userId}`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${$rootScope.User.LoginHash}`
        }
      })
    }

    this.addBooking = function (newBooking) {
      return fetchWrapper(`https://localhost:44375/api/Bookings`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${$rootScope.User.LoginHash}`
        },
        body: JSON.stringify(newBooking)
      })
    }

    this.getAvailability = function(startDate, endDate){
      return fetchWrapper(`https://localhost:44375/api/Bookings?startDate=${startDate}&endDate=${endDate}`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${$rootScope.User.LoginHash}`
        }
      })
    }
  });