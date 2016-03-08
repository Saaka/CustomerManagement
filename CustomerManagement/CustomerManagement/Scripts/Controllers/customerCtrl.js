angular.module('customerManager')
    .controller('CustomerCtrl', ['$scope', '$state', 'alertService', 'customerService', function ($scope, $state, alertService, customerService) {
        $scope.customer = {};
        $scope.formValid = false;

        $scope.goBack = function () {
            alertService.confirm('Confirm', 'Go back to customer list?', function (isCanceled) {
                if (isCanceled) {
                    $state.go('list');
                }
            });
        };

        $scope.saveCustomer = function () {
            customerService.saveCustomer($scope.customer)
                .then(function (res) {
                    alertService.success('Success', 'Customer saved!', function () {
                        $state.go('list');
                    });
                })
                .catch(function (err) {
                    alertService.error('Error', err);
                });
        };
    }]);