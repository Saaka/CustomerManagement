angular.module('customerManager')
    .service('customerService', ['$http', '$q', function ($http, $q) {
        var address = '/api/customers'

        this.loadCustomers = function () {
            var defer = $q.defer();
            $http.get(address)
                .success(function (res) {
                    defer.resolve(res);
                })
                .error(function (err) {
                    derer.reject(err);
                });
            return defer.promise;
        };

        this.saveCustomer = function (customer) {
            var defer = $q.defer();
            $http.post(address, customer)
                .success(function (res) {
                    defer.resolve(res);
                })
                .error(function (err) {
                    defer.reject(err);
                });
            return defer.promise;
        }
    }]);