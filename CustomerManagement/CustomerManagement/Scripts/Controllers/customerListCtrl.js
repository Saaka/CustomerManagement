angular.module('customerManager')
    .controller('CustomerListCtrl', ['$scope', 'toaster', function ($scope, toaster) {

        toaster.pop('info', 'Hello', 'Welcome to customer manager');
    }]);