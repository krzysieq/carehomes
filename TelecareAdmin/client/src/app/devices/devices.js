angular.module('telecareAdmin.devices', [

])

    .controller('DevicesCtrl', function($scope, $modalInstance, participant, deviceResource) {
        $scope.participant = participant;

        var updateDevices = function() {
            deviceResource.query({participantId: participant.participantId}).$promise.then(
                function(devices) {
                    $scope.devices = devices;
                },
                function(reason) {
                    alert('Failed to retrieve data: ' + reason);
                }
            );
        };

        $scope.authorise = function(device) {
            deviceResource.activate({
                participantId: participant.participantId,
                deviceId: device.id
            }).$promise.then(
                function(response) {
                    var authWindow = window.open(response.authUrl, 'Device authorisation',
                        'centerscreen,width=800,height=500,chrome=yes,scrollbars=yes');
                    var timer = setInterval(function() {
                        console.log(authWindow);
                        if(authWindow.closed) {
                            clearInterval(timer);
                            updateDevices();
                        }
                    }, 1000);
                },
                function(reason) {
                    alert('Failed to retrieve data: ' + reason);
                }
            );
        };

        $scope.deauthorise = function(device) {
            if (confirm("Are you sure you want to remove this device?")) {
                deviceResource.deactivate({
                    participantId: participant.participantId,
                    deviceId: device.id
                }).$promise.then(
                    function() {
                        updateDevices();
                    }
                );
            }
        };

        $scope.ok = function() {
            $modalInstance.close();
        };

        updateDevices();
    })
;