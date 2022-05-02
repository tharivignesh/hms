hmsApp.controller('bookingsController', function bookingsController($scope, $rootScope, hmsService) {
    $rootScope.loading = true;
    $scope.roomList = []
    $scope.bookingList = []
    $scope.newBooking = {
        StartDate: new Date(),
        EndDate: new Date()
    }

    async function initialize() {
        console.debug('initialize()')
        await hmsService.authorization()
        if ($rootScope.authorized) {
            $scope.roomList = await hmsService.getRooms()
            await getBookings()
            console.log($scope.bookingList)
        }
        $rootScope.loading = false;
        $scope.$apply()
    }

    $scope.BookRoom = function () {
        $('#addRoomModal').modal('show');
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
        await getBookings()
        console.log($scope.roomList)
        $('#addRoomModal').modal('hide');
        $rootScope.loading = false;
        $scope.$apply()
    }

    async function getBookings() {
        let blist = await hmsService.getBookings()
        for (let i = 0; i < blist.data.length; i++) {
            let element = blist[i]
            $scope.bookingList.push({
                RoomNo: $scope.roomList.data.find(x => x.Id === element.RoomId).RoomNo,
                RoomName: $scope.roomList.data.find(x => x.Id === element.RoomId).RoomName,
                BookedBy: element.BookedBy,
                FromDate: element.StartDate,
                ToDate: element.EndDate
            })
        }
    }

    initialize()
})