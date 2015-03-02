/**
 * Each section of the site has its own module. It probably also has
 * submodules, though this boilerplate is too simple to demonstrate it. Within
 * `src/app/home`, however, could exist several additional folders representing
 * additional modules that would then be listed as dependencies of this one.
 * For example, a `note` section could have the submodules `note.create`,
 * `note.delete`, `note.edit`, etc.
 *
 * Regardless, so long as dependencies are managed correctly, the build process
 * will automatically take take of the rest.
 *
 * The dependencies block here is also where component dependencies should be
 * specified, as shown below.
 */
angular.module( 'telecareAdmin.participants', [
  'ui.router',
    'telecareAdmin.participants.editParticipant',
    'telecareAdmin.participants.newParticipant',
    'telecareAdmin.participants.activationInfo',
    'telecareAdmin.devices'
])

/**
 * Each section or module of the site can also have its own routes. AngularJS
 * will handle ensuring they are all available at run-time, but splitting it
 * this way makes each module more "self-contained".
 */
.config(function config( $stateProvider ) {
  $stateProvider.state( 'participants', {
    url: '/participants',
    views: {
      "main": {
        controller: 'ParticipantsCtrl',
        templateUrl: 'participants/participants.tpl.html'
      }
    },
    data:{ pageTitle: 'Participants' }
  });
})

/**
 * And of course we define a controller for our route.
 */
.controller( 'ParticipantsCtrl', function ParticipantsController($scope, $modal, $filter, participantsData) {

        $scope.participants = participantsData;
        $scope.filteredParticipants = $scope.participants;

        $scope.resetSearch = function() {
            $scope.search = {
                query: '',
                activated: 'all'
            };
        };

        $scope.resetSearch();

        $scope.$watch('search', function() {
            $scope.updateParticipants();
            $scope.updatePagination();
        }, true);



        $scope.updateParticipants = function() {
            var activated = $scope.search.activated == 'true' ? true :
                    $scope.search.activated == 'false' ? false : '';
            $scope.filteredParticipants = $filter('filter')($scope.participants, {
                name: $scope.search.query,
                activated: activated});
        };

        $scope.edit = function(participant) {
            var modalInstance = $modal.open({
                templateUrl: 'participants/editParticipant/editParticipant.tpl.html',
                controller: 'EditParticipantCtrl',
                backdrop: 'static',
                windowClass: 'modal-standard',
                resolve: {
                    participant: function() {
                        return angular.copy(participant);
                    }
                }
            });

            modalInstance.result.then(function(editedParticipant) {
                participant.name = editedParticipant.name;
                participant.dob = editedParticipant.dob;
            }, function(reason) {
                if (reason === 'delete') {
                    participant = null;
                }
            });
        };

        $scope.newParticipant = function() {
            var modalInstance = $modal.open({
                templateUrl: 'participants/newParticipant/newParticipant.tpl.html',
                controller: 'NewParticipantCtrl',
                backdrop: 'static',
                windowClass: 'modal-standard',
                resolve: {
                    participant: function() {
                        return {};
                    }
                }
            });

            modalInstance.result.then(function(createdParticipant) {
                $scope.participants.push(createdParticipant);
                $scope.updateParticipants();
                $scope.activationInfo(createdParticipant);
            }, function() {

            });
        };

        $scope.activationInfo = function(participant) {
            var modalInstance = $modal.open({
                templateUrl: 'participants/activationInfo/activationInfo.tpl.html',
                controller: 'ActivationInfoCtrl',
                backdrop: 'static',
                windowClass: 'modal-standard',
                resolve: {
                    participant: function() {
                        return participant;
                    }
                }
            });

            modalInstance.result.then(function() {

            }, function() {

            });
        };

        $scope.manageDevices = function(participant) {
            var modalInstance = $modal.open({
                templateUrl: 'devices/devices.tpl.html',
                controller: 'DevicesCtrl',
                windowClass: 'modal-large',
                resolve: {
                    participant: function() {
                        return participant;
                    }
                }
            });
        };


        /* Pagination code */

        $scope.paginatedParticipants = {};

        $scope.currentPage = 1;
        $scope.itemsPerPage = 10;

        $scope.setPage = function(page) {
            $scope.currentPage = page;
        };

        $scope.pageCount = function() {
            return Math.ceil($scope.filteredParticipants.length / $scope.itemsPerPage);
        };

        $scope.updatePagination = function() {
            var begin = (($scope.currentPage - 1) * $scope.itemsPerPage),
                end = begin + $scope.itemsPerPage;
            $scope.paginatedParticipants = $scope.filteredParticipants.slice(begin, end);
        };

        $scope.$watch('currentPage + itemsPerPage', $scope.updatePagination);
})

;

