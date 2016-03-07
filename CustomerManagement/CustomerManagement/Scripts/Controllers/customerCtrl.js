angular.module('customerManager')
    .controller('CustomerCtrl', ['$scope', 'toaster', '$state', function ($scope, toaster, $state) {
        
        $scope.saveCustomer = function () {

            toaster.pop('success', 'Hello', 'Added');
            $state.go('list');
        };

        toaster.pop('info', 'Hello', 'Add new customer');
    }]);