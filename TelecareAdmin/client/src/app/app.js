angular.module( 'telecareAdmin', [
  'templates-app',
  'templates-common',
  'telecareAdmin.participants',
  'ui.router',
    'ui.bootstrap',
    'ngResource',
    'nya.bootstrap.select',
    'angular-loading-bar',
    'telecareAdminFilters',
    'telecareAdminDirectives',
    'telecareAdminServices'
])

.config( function myAppConfig ( $stateProvider, $urlRouterProvider ) {
  $urlRouterProvider.otherwise( '/' );
})

.run( function run ($rootScope, $http, Base64) {
      $rootScope.PATTERN_DATE = /^[0-9]{2}\/[0-9]{2}\/[0-9]{4}$/;

      /*
       * WARNING: These credentials should be changed when deploying to production
       */
      var username = 'admin',
          password = 'hc3OpgYAHnJC';
      $http.defaults.headers.common['Authorization'] = 'Basic ' + Base64.encode(username + ':' + password);
})

.controller( 'AppCtrl', function AppCtrl ( $scope, $location ) {
  $scope.$on('$stateChangeSuccess', function(event, toState, toParams, fromState, fromParams){
    if ( angular.isDefined( toState.data.pageTitle ) ) {
      $scope.pageTitle = toState.data.pageTitle + ' | Telecare Administration' ;
    }
  });
})

.config(['cfpLoadingBarProvider', function(cfpLoadingBarProvider) {
  cfpLoadingBarProvider.includeSpinner = false;
}])

;

/*
 * Helper methods
 */

String.prototype.contains = function(it) {
  return this.indexOf(it) != -1;
};

