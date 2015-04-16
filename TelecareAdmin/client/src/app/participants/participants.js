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
    url: '/',
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
.controller( 'ParticipantsCtrl', function ParticipantsController($scope, $modal, $filter, participantsResource,
                                                                 participantResource, activationResource) {

        var retrieveParticipants = function() {
            participantsResource.query().$promise.then(
                function(participants) {
                    $scope.participants = participants;
                    $scope.filteredParticipants = $scope.participants;
                    $scope.resetSearch();
                },
                function(reason) {
                    alert('Failed to retrieve data: ' + reason);
                }
            );
        };

        $scope.resetSearch = function() {
            $scope.search = {
                query: '',
                activated: 'all'
            };
            $scope.updateView();
        };

        $scope.$watch('search', function() {
            $scope.updateView();
        }, true);


        $scope.updateView = function() {
            $scope.updateParticipants();
            $scope.updatePagination();
        };

        $scope.updateParticipants = function() {
            var activated = $scope.search.activated == 'true' ? true :
                    $scope.search.activated == 'false' ? false : '';
            $scope.filteredParticipants = $filter('filter')($scope.participants, function(value) {
                if (value.firstName && value.lastName) {
                    var name = (value.firstName + " " + value.lastName + " " + value.firstName).toLowerCase(),
                        query = $scope.search.query.toLowerCase();
                    return (name.contains(query) || $filter('simpleDate')(value.dob).contains(query)) &&
                        value.activated.toString().contains(activated);
                } else {
                    return false;
                }

            });
        };

        $scope.refreshActivations = function() {
            activationResource.update().$promise.then(
                function() {
                    retrieveParticipants();
                },
                function() {
                    alert('Failed to retrieve data');
                }
            );
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
                // update the resource object
                participant.firstName = editedParticipant.firstName;
                participant.lastName = editedParticipant.lastName;
                participant.dob = editedParticipant.dob;
                participant.gender = editedParticipant.gender;

                // push changes to the server
                console.log(participant);
                participantResource.update({participantId: participant.participantId}, participant);

            }, function(reason) {
                // modal dismissed
                if (reason === 'delete') {
                    participantResource.deleteParticipant({participantId: participant.participantId}, participant);
                    $scope.participants.splice($scope.participants.indexOf(participant));
                    $scope.updateView();
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
                participantsResource.save(createdParticipant).$promise.then(
                    function(response) {
                        $scope.participants.push(response);
                        $scope.updateView();
                        $scope.activationInfo(response);
                    }
                );
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

        retrieveParticipants();
})

;

