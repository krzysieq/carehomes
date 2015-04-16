angular.module('telecareAdminDirectives', [])

    .directive('easySubmit', function() {
        return {
            restrict: 'A',
            scope: {
                btn: '@easySubmit'
            },
            link: function(scope, element) {
                element.bind('keyup', function(event) {
                    if (event.keyCode == 13) {
                        document.getElementById(scope.btn).click();
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

    .directive('validateDate', function(dateFilter) {
        var datePattern = /^[0-9]{2}\/[0-9]{2}\/[0-9]{4}$/;
        return {
            require: 'ngModel',
            link: function(scope, element, attrs, ngModelCtrl) {
                ngModelCtrl.$formatters.push(function(modelValue) {
                    return dateFilter(modelValue, 'dd/MM/yyyy');
                });

                ngModelCtrl.$parsers.push(function(viewValue) {
                    var parsedDate =  moment(viewValue, 'DD/MM/YYYY');
                    if (parsedDate.isValid() && datePattern.test(viewValue)) {
                        ngModelCtrl.$setValidity('validateDate', true);
                        return parsedDate.toDate();
                    } else {
                        ngModelCtrl.$setValidity('validateDate', false);
                        return undefined;
                    }
                });
            }
        };
    })

    // from http://stackoverflow.com/a/21328625
    .directive('printDiv', function () {
        return {
            restrict: 'A',
            link: function(scope, element, attrs) {
                element.bind('click', function(evt){
                    evt.preventDefault();
                    printElem(attrs.printDiv);
                });

                function printElem(elem)
                {
                    printWithIframe(angular.element(document.querySelector(elem)).html());
                }

                function printWithIframe(data)
                {
                    if (!document.getElementById('printf')) {
                        angular.element(document.documentElement).append('<iframe id="printf" name="printf"></iframe>');

                        var mywindow = window.frames["printf"];
                        mywindow.document.write('<html><head><title></title><style>@page {margin: 25mm 25mm 25mm 25mm}</style>' +
                        '</head><body><div>' +
                        data +
                        '</div></body></html>');

                        angular.element(mywindow.document).ready(function(){
                            mywindow.print();
                            setTimeout(function(){
                                    angular.element(document.getElementById('printf')).remove();
                                },
                                2000);
                        });
                    }

                    return true;
                }
            }
        };
    })

    .directive('showValidation', function() {
        return {
            restrict: "A",
            link: function (scope, element, attrs, ctrl) {
                scope.$watch(function () {
                    return element.hasClass('ng-invalid') && element.hasClass('ng-dirty');
                }, function (isInvalid) {
                    element.parent().toggleClass('has-error', isInvalid);
                });
            }
        };
    })

;