angular.module('telecareAdmin.participants.newParticipant', [

])

    .controller('NewParticipantCtrl', function($scope, $modalInstance, participant) {
        $scope.participant = participant;

        angular.extend($scope.participant, {
            enrollmentDate: new Date(),
            activated: false,
            activationCode: ""
        });

        $scope.ok = function() {
            $modalInstance.close($scope.participant);
        };

        $scope.cancel = function() {
            $modalInstance.dismiss('cancel');
        };
    })
;
