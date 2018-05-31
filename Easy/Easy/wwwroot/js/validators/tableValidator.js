window.registerToAngular(function (app) {
    app.directive('table', function () {
        return {
            require: "?ngModel",
            link: function (scope, elm, attrs, ngModel) {
                if (ngModel && attrs.ngRequired === "true") {
                    //debugger
                    scope.$watch(function () { return ngModel.$modelValue && ngModel.$modelValue.length; }, function () {
                        ngModel.$validate();
                    });

                    ngModel.$validators.length = function () {
                        var arr = ngModel.$modelValue;
                        if (!arr) { return false; }

                        return arr.length > 0;
                    };
                }
                return;
            }
        };
    });
});