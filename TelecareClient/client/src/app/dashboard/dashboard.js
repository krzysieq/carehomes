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
angular.module( 'telecareDashboard.dashboard', [
  'ui.router',
    'ui.bootstrap'
])

/**
 * Each section or module of the site can also have its own routes. AngularJS
 * will handle ensuring they are all available at run-time, but splitting it
 * this way makes each module more "self-contained".
 */
.config(function config( $stateProvider ) {
  $stateProvider.state( 'dashboard', {
    url: '/',
    views: {
      "main": {
        controller: 'DashboardCtrl',
        templateUrl: 'dashboard/dashboard.tpl.html'
      }
    },
    data:{ pageTitle: 'Dashboard' }
  });
})

/**
 * And of course we define a controller for our route.
 */
.controller( 'DashboardCtrl', function DashboardController( $scope, $filter, focus, aggregateThings,
                                                            participantResource, thingResource) {

        var retrieveParticipants = function() {
            participantResource.query().$promise.then(
                function(participants) {
                    $scope.allParticipants = participants;
                    afterDataResolved();
                },
                function() {
                    alert('Failed to retrieve Participants data');
                }
            );
        };

        var afterDataResolved = function() {
            $scope.$watch('search.query', function() {
                $scope.updateParticipants();
                $scope.updatePagination();
            }, true);
        };

        $scope.participant = null;

        retrieveParticipants();

        //$scope.things = aggregateThings(thingsData($scope.participant));
        //
        ////console.log(data.getParticipants());
        //
        //$scope.allParticipants = participantsData;
        //$scope.filteredParticipants = $scope.allParticipants;

        var resetSearch = function() {
            $scope.search = {
                query: '',
                active: true
            };
        };

        resetSearch();

        $scope.focusSearch = function() {
            resetSearch();
            $scope.things = null;
            $scope.thing = null;
            $scope.participant = null;
        };

        $scope.updateParticipants = function() {
            $scope.filteredParticipants = $filter('filter')($scope.allParticipants, {
                fullName: $scope.search.query
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



        $scope.selectParticipant = function(participant) {
            $scope.participant = participant;
            $scope.search.query  = participant.fullName;
            $scope.search.active = false;

            thingResource.get({participantId: participant.participantId}).$promise.then(
                function(things) {
                    $scope.things = aggregateThings(things);
                },
                function(reason) {
                    alert('Failed to retrieve data');
                }
            );
        };

        $scope.init = function() {
            focus('search-field');
        };


        $scope.thing = null;

        $scope.showThing = function(thing) {
            $scope.thing = thing;
        };



        $scope.chartConfig = {
            options: {
                chart: {
                    type: 'line',
                    backgroundColor: 'transparent'
                },
                tooltip: {
                    style: {
                        padding: 10,
                        fontWeight: 'bold'
                    }
                }
            },
            title: {
                text: null
            },
            loading: false,
            xAxis: {
                currentMin: 0,
                currentMax: 20,
                title: {text: null}
            },
            size: {
                height: 200
            }
        };
})

.directive('thingTile', function() {
        return {
            restrict: 'E',
            scope: {
                thing: '='
            },
            templateUrl: 'dashboard/tile.tpl.html',
            controller: function($scope) {
               $scope.type = $scope.thing.value ? 'single' : 'list';
            }
        };
    })

;


