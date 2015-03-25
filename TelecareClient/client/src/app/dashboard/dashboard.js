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
    url: '/dashboard',
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
.controller( 'DashboardCtrl', function DashboardController( $scope, $filter, participantsData,
                                                                focus, aggregateThings, thingsData) {

        $scope.participant = null;

        $scope.things = aggregateThings(thingsData($scope.participant));

        console.log($scope.things);

        $scope.allParticipants = participantsData;
        $scope.filteredParticipants = $scope.allParticipants;

        $scope.search = {
            query: '',
            active: true
        };

        $scope.$watch('search.query', function() {
            $scope.updateParticipants();
            $scope.updatePagination();
        }, true);


        $scope.updateParticipants = function() {
            $scope.filteredParticipants = $filter('filter')($scope.allParticipants, {
                name: $scope.search.query
            });
        };


        /* Pagination code */

        $scope.paginatedParticipants = {};

        $scope.currentPage = 1;
        $scope.itemsPerPage = 2;

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
            $scope.search.query  = participant.name;
            $scope.search.active = false;
        };

        $scope.init = function() {
            focus('search-field');
        };


        $scope.thing = null;

        $scope.showThing = function(thing) {
            $scope.thing = thing;
        };




        //This is not a highcharts object. It just looks a little like one!
        $scope.chartConfig = {

            options: {
                //This is the Main Highcharts chart config. Any Highchart options are valid here.
                //will be overriden by values specified below.
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
            //The below properties are watched separately for changes.

            //Series object (optional) - a list of series using normal highcharts series options.
            series: [{
                data: [10, 15]
            }],
            //Title configuration (optional)
            title: {
                text: null
            },
            //Boolean to control showng loading status on chart (optional)
            //Could be a string if you want to show specific loading text.
            loading: false,
            //Configuration for the xAxis (optional). Currently only one x axis can be dynamically controlled.
            //properties currentMin and currentMax provied 2-way binding to the chart's maximimum and minimum
            xAxis: {
                currentMin: 0,
                currentMax: 20,
                title: {text: null}
            },
            //Whether to use HighStocks instead of HighCharts (optional). Defaults to false.
            useHighStocks: false,
            //size (optional) if left out the chart will default to size of the div or something sensible.
            size: {
            //    width: 400,
                height: 200
            },
            //function (optional)
            func: function (chart) {
                //setup some logic for the chart
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


