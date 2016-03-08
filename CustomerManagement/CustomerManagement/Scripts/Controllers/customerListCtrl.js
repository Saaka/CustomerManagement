﻿angular.module('customerManager')
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

        init();
    }]);