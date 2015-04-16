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

    .directive('focusIf', function($timeout) {
        return {
            restrict: 'A',
            scope: {
                condition: '=focusIf'
            },
            link: function(scope, element, attrs) {
                scope.$watch('condition', function(value) {
                    if (!value) {
                        $timeout(function() {
                            element[0].blur();
                        });
                        console.log("BLUR");
                    }
                });
                element.on('blur', function(event) {
                    console.log("FOCUS");
                    $timeout(function() {
                        element[0].focus();
                    });
                    event.stopImmediatePropagation();
                    event.preventDefault();
                });
            }
        };
    })

;