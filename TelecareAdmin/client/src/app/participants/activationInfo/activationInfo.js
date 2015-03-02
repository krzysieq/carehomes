angular.module('telecareAdmin.participants.activationInfo', [

])

    .controller('ActivationInfoCtrl', function($scope, $modalInstance, participant) {
        $scope.participant = participant;

        $scope.ok = function() {
            $modalInstance.close();
        };
    })
;