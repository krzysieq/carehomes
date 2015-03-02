angular.module('telecareAdminDirectives', [])

    .directive('easySubmit', function() {
        return {
            restrict: 'A',
            scope: {
                action: '=easySubmit'
            },
            link: function(scope, element) {
                element.bind('keyup', function(event) {
                    if (event.keyCode == 13) {
                        scope.action();
                    }
                });
            }
        };
    })

    .directive('btnLoading', function() {
        return {
            restrict: 'A',
            scope: {
                loadingText: '@btnLoading'
            },
            link: function(scope, element) {
                scope.$observe('loadingText', function(value) {
                    if (value) {
                        element.enable();
                    } else {
                        element.disable().text(value);
                    }
                });
            }
        };
    })

;