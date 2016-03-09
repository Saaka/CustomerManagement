angular.module('customerManager')
    .controller('CustomerListCtrl', ['$scope', 'customerService', 'alertService', function ($scope, customerService, alertService) {
        $scope.customers = [];
        $scope.showLoader = false;

        var init = function () {
            $scope.showLoader = true;
            customerService
                .loadCustomers()
                .then(function (res) {
                    $scope.customers = res;
                    $scope.showLoader = false;
                })
                .catch(function (err) {
                    alertService.error("Can't load customers", err.message);
                    $scope.showLoader = false;
                });
        };

        $scope.deleteCustomer = function (customer) {
            alertService.confirm("Delete customer?", "Delete customer " + customer.name + "?", function (confirmation) {
                if (confirmation) {

                    var index = $scope.customers.indexOf(customer);
                    if (index >= 0) {
                        customerService.deleteCustomer(customer.id)
                            .then(function (res) {
                                $scope.customers.splice(index, 1);
                                if (!$scope.$$phase) {
                                    $scope.$apply();
                                }
                                alertService.success('Success', 'Customer deleted');
                            })
                            .catch(function (err) {
                                alertService.error("Can't delete customer", err.message);
                            });
                    }
                }
            });
        };

        init();
    }]);