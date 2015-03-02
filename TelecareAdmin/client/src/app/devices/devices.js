angular.module('telecareAdmin.devices', [

])

    .controller('DevicesCtrl', function($scope, $modalInstance, participant) {
        $scope.participant = participant;

        $scope.devices = [{
            vendor: 'Nest',
            picture: 'assets/devices/nest.png',
            sensors: [{
                name: 'Thermostat',
                status: 2
            }, {
                name: 'Protect',
                status: 1
            }],
            authorised: true
        }, {
            vendor: 'Kinect',
            picture: 'assets/devices/kinect.jpg',
            sensors: [{
                name: 'Kinect',
                status: 0
            }],
            authorised: false
        }];

        $scope.authorise = function(device) {
            alert('Authorisation callback for API: ' + device.vendor);
        };

        $scope.deauthorise = function(device) {
            alert('Deauthorisation callback for API: ' + device.vendor);
        };

        $scope.ok = function() {
            $modalInstance.close();
        };
    })
;