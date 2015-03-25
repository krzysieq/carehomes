angular.module('telecareDashboardDirectives', [])

    .directive('keyboardCycle', function() {
        return {
            restrict: 'A',
            scope: {
                selector: '=',
                activeClass: '='
            },
            link: function(scope, element, attrs) {
                element.on('keydown', function(event) {
                    if (event.keyCode == 40) { // arrow down

                    }
                });
            }
        };
    })

;