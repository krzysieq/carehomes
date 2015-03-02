angular.module('telecareAdminFilters', [])
    .filter('simpleDate', ['dateFilter', function(dateFilter) {
        return function(input) {
            return dateFilter(input, 'dd/MM/yyyy');
        };
    }]);