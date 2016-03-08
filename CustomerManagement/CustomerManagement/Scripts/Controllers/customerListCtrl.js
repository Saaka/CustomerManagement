angular.module('customerManager')
    .controller('CustomerListCtrl', ['$scope', 'customerService', 'alertService', function ($scope, customerService, alertService) {
        $scope.customers = [];

        var init = function () {
            alertService.loader();
            customerService.loadCustomers()
                .then(function (res) {
                    $scope.customers = res;
                    alertService.close();
                })
                .catch(function (err) {
                    alertService.close();
                    alertService.error("Can't load customers", err);
                });
        };

        $scope.deleteCustomer = function (customer) {
            alertService.confirm("Delete customer?", "Delete customer " + customer.name, function (confirmation) {
                if (confirmation) {

                    var index = $scope.customers.indexOf(customer);
                    if (index) {
                        $scope.customers.splice(index, 1);
                        $scope.$apply();
                    }
                }
            });
        };

        init();
    }]);