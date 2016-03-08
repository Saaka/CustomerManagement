angular.module('customerManager')
    .controller('CustomerCtrl', ['$scope', '$state', 'alertService', function ($scope, $state, alertService) {

        $scope.goBack = function () {
            alertService.confirm('Confirm', 'Go back to customer list?', function (isCanceled) {
                if (isCanceled) {
                    $state.go('list');
                }
            });
        };

        $scope.saveCustomer = function () {

            alertService.success('Success', 'Customer saved!', function () {
                $state.go('list');
            });
        };
    }]);