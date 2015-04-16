angular.module( 'telecareDashboard', [
  'templates-app',
  'templates-common',
  'telecareDashboard.dashboard',
  'telecareDashboard.about',
  'ui.router',
    'angularMoment',
    'ngAnimate',
    'ngSanitize',
    'ngResource',
    'customFilters',
    'telecareDashboardServices',
    'telecareDashboardDirectives',
    'highcharts-ng',
    'sprintf',
    'angular-loading-bar'
])

.config( function myAppConfig ( $stateProvider, $urlRouterProvider ) {
  $urlRouterProvider.otherwise( '/' );
})

.run( function run () {
})

.controller( 'AppCtrl', function AppCtrl ( $scope, $location ) {
  $scope.$on('$stateChangeSuccess', function(event, toState, toParams, fromState, fromParams){
    if ( angular.isDefined( toState.data.pageTitle ) ) {
      $scope.pageTitle = toState.data.pageTitle;
    }
  });
})

;



/* Helper methods */

Array.prototype.first = function() {
    return this[0];
};

Array.prototype.last = function() {
    return this[this.length - 1];
};

Array.prototype.sum = Array.prototype.sum || function() {
    return this.reduce(function(sum, a) {
        return sum + Number(a);
    }, 0);
};

Array.prototype.average = Array.prototype.average || function() {
    return this.sum() / (this.length || 1);
};

Array.prototype.max = Array.prototype.max || function() {
    return Math.max.apply(null, this);
};

Array.prototype.min = Array.prototype.min || function() {
    return Math.min.apply(null, this);
};

angular.merge =function(dst){
    var slice = [].slice;
    var isArray = Array.isArray;
    var baseExtend = function(dst, objs, deep) {
        for (var i = 0, ii = objs.length; i < ii; ++i) {
            var obj = objs[i];
            if (!angular.isObject(obj) && !angular.isFunction(obj)) {
                continue;
            }
            var keys = Object.keys(obj);
            for (var j = 0, jj = keys.length; j < jj; j++) {
                var key = keys[j];
                var src = obj[key];
                if (deep && angular.isObject(src)) {
                    if (!angular.isObject(dst[key])) {
                        dst[key] = isArray(src) ? [] : {};
                    }
                    baseExtend(dst[key], [src], true);
                } else {
                    dst[key] = src;
                }
            }
        }

        return dst;
    };
    return baseExtend(dst, slice.call(arguments, 1), true);
};

