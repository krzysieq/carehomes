angular.module('telecareAdmin.participants.editParticipant', [

])

.controller('EditParticipantCtrl', function($scope, $modalInstance, $window, participant) {
        $scope.participant = participant;

        $scope.ok = function() {
            $modalInstance.close($scope.participant);
        };

        $scope.cancel = function() {
            $modalInstance.dismiss('cancel');
        };

        $scope.deleteParticipant = function() {
            if ($window.confirm("Are you sure you want to delete Participant: " + $scope.participant.firstName + " " +
                $scope.participant.lastName  + '?')) {
                $modalInstance.dismiss('delete');
            }
        };
    })
;