angular.module('customerManager')
  .config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {

      $urlRouterProvider.otherwise('/');

      $stateProvider
        .state('list', {
            url: '/',
            templateUrl: 'Templates/CustomerList.html'
        })
        .state('customer', {
            url: '/customer',
            templateUrl: 'Templates/Customer.html',
            params: { cust: {}}
        });

  }]);