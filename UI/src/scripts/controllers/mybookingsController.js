'use strict';

hmsApp.controller('mybookingsController', function mybookingsController($scope, $rootScope, hmsService) {
    $rootScope.loading = true;
    $scope.roomList = []
    $scope.bookingList = []
    $scope.newBooking = {
        StartDate: new Date(),
        EndDate: new Date()
    }

    $scope.checkAvailability = {
        StartDate: new Date(),
        EndDate: new Date()
    }

    async function initialize() {
        console.debug('initialize()')
        await hmsService.authorization()
        if ($rootScope.authorized) {
            $scope.roomList = await hmsService.getRooms()
            await getMyBookings($rootScope.User.Id)
            console.log($scope.bookingList)
        }
        $rootScope.loading = false;
        $scope.$apply();
    }

    $scope.BookRoom = function () {
        $('#addRoomModal').modal('show');
    }

    $scope.ShowAvailability = function () {
        $('#checkAvailabilityModal').modal('show');
        $scope.availableList = []
    }

    $scope.AddNewBooking = async function () {
        $rootScope.loading = true;
        console.log($scope.newBooking);
        var newBooking = {
            RoomId: $scope.newBooking.Room,
            StartDate: $scope.newBooking.StartDate,
            EndDate: $scope.newBooking.EndDate,
            BookedBy: $rootScope.User.Id
        }
        console.log(newBooking);
        await hmsService.addBooking(newBooking)
        await getMyBookings($rootScope.User.Id)
        console.log($scope.roomList)
        $('#addRoomModal').modal('hide');
        $rootScope.loading = false;
        $scope.$apply()
    }

    $scope.CheckAvailability = async function () {
        let startDate =$scope.checkAvailability.StartDate.toISOString()
        let endDate = $scope.checkAvailability.EndDate.toISOString()
        console.log(startDate, ' - ', endDate)
        $scope.availableList = await hmsService.getAvailability(startDate, endDate)
        $scope.$apply()
    }

    async function getMyBookings(userId) {
        let blist = await hmsService.getMyBookings(userId)
        for (let i = 0; i < blist.data.length; i++) {
            let element = blist[i]
            $scope.bookingList.push({
                RoomNo: $scope.roomList.data.find(x => x.Id === element.RoomId).RoomNo,
                RoomName: $scope.roomList.data.find(x => x.Id === element.RoomId).RoomName,
                BookedBy: $rootScope.User.UserName,
                FromDate: element.StartDate,
                ToDate: element.EndDate
            })
        }
    }

    initialize()
});