'use strict';

hmsApp.controller('mainController', function mainController($scope, $rootScope, hmsService) {

  $scope.roomList = []
  initialize();

  async function initialize() {
    console.debug('initialize()')
    $rootScope.loading = true
    await hmsService.authorization()
    if ($rootScope.authorized) {
      $scope.roomList = await hmsService.getRooms()
      console.log($scope.roomList)
    }
    $rootScope.loading = false;
    $scope.$apply()
  }

  $scope.AddRoom = function () {
    $scope.newRoom = {}
    $('#addRoomModal').modal('show');
  }

  $scope.AddNewRoom = async function () {
    console.log($scope.newRoom);
    await hmsService.addRoom($scope.newRoom)
    $scope.roomList = await hmsService.getRooms()
    $scope.$apply();
  }

});