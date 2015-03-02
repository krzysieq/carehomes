angular.module( 'telecareAdmin', [
  'templates-app',
  'templates-common',
  'telecareAdmin.participants',
  'ui.router',
    'ui.bootstrap',
    'telecareAdminFilters',
    'telecareAdminDirectives',
    'telecareAdminServices'
])

.config( function myAppConfig ( $stateProvider, $urlRouterProvider ) {
  $urlRouterProvider.otherwise( '/participants' );
})

.run( function run () {
})

.controller( 'AppCtrl', function AppCtrl ( $scope, $location ) {
  $scope.$on('$stateChangeSuccess', function(event, toState, toParams, fromState, fromParams){
    if ( angular.isDefined( toState.data.pageTitle ) ) {
      $scope.pageTitle = toState.data.pageTitle + ' | Telecare Administration' ;
    }
  });
})

;

